using easily.framework.core.Bootstrappers;
using easily.framework.tools.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    public abstract class DependencyInjectionRegistrarBase : IDependencyInjectionRegistrar
    {
        #region 辅助方法
        /// <summary>
        /// 获取指定程序集的所有类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        protected Type[] GetAssemblyTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch
            {
                return Type.EmptyTypes;
            }
        }

        /// <summary>
        /// 是否禁用依赖注入
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual bool IsDisableDependencyInjection(Type type)
        {
            return type.IsDefined(typeof(DisableDependencyInjectionAttribute), true);
        }

        /// <summary>
        /// 获取指定类型的依赖注入特性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual DependencyAttribute? GetDependencyAttributeOrNull(Type type)
        {
            return type.GetCustomAttribute<DependencyAttribute>(true);
        }

        /// <summary>
        /// 获取依赖注入类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dependencyAttribute"></param>
        /// <returns></returns>
        protected virtual ServiceLifetime? GetLifeTimeOrNull(Type type, DependencyAttribute? dependencyAttribute)
        {
            return dependencyAttribute?.Lifetime ?? GetServiceLifetimeFromClass(type);
        }

        /// <summary>
        /// 从接口中获取依赖注入类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual ServiceLifetime? GetServiceLifetimeFromClass(Type type)
        {
            if (typeof(ITransientDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Transient;
            }

            if (typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Singleton;
            }

            if (typeof(IScopedDependency).GetTypeInfo().IsAssignableFrom(type))
            {
                return ServiceLifetime.Scoped;
            }

            return null;
        }

        /// <summary>
        /// 获取需要注入的类型列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dependencyAttribute"></param>
        /// <returns></returns>
        protected virtual List<Type> GetExposedServiceTypes(Type type, DependencyAttribute? dependencyAttribute)
        {
            List<Type> exposedServices = dependencyAttribute?.RegisterTypes?.ToList() ?? new List<Type>();

            // 如果特性中没有指定注入的类型，则从实现的接口中查找
            if (!exposedServices.Any())
            {
                List<Type> skipInterfaces = [typeof(ITransientDependency), typeof(ISingletonDependency), typeof(IScopedDependency)];
                foreach (var interfaceType in type.GetTypeInfo().GetInterfaces())
                {
                    if (skipInterfaces.Contains(interfaceType)) continue;
                    exposedServices.AddIfNotContains(interfaceType);
                }
            }
            
            // 添加本身
            exposedServices.AddIfNotContains(type);

            return exposedServices;
        }

        /// <summary>
        /// 创建注入描述对象
        /// </summary>
        /// <param name="implementationType"></param>
        /// <param name="exposingServiceType"></param>
        /// <param name="lifeTime"></param>
        /// <returns></returns>
        protected virtual ServiceDescriptor CreateServiceDescriptor(Type implementationType,  Type exposingServiceType, ServiceLifetime lifeTime)
        {
            // 处理泛型类型
            Type serviceType = exposingServiceType;
            if (implementationType.IsGenericTypeDefinition && exposingServiceType.IsGenericType)
            {
                var genericArguments = exposingServiceType.GetGenericArguments();
                if (genericArguments.Length > 0)
                {
                    serviceType = exposingServiceType.GetGenericTypeDefinition();
                }
            }

            return ServiceDescriptor.Describe(
                serviceType,
                implementationType,
                lifeTime
            );
        }
        #endregion

        /// <summary>
        /// 注册指定的程序集
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        public virtual void AddAssembly(IServiceCollection services, Assembly assembly)
        {
            var types = GetAssemblyTypes(assembly)
                .Where(
                    type => type != null &&
                            type.IsClass &&
                            !type.IsAbstract
                ).ToArray();

            AddTypes(services, types);
        }

        /// <summary>
        /// 注册多个类型
        /// </summary>
        /// <param name="services"></param>
        /// <param name="types"></param>
        public virtual void AddTypes(IServiceCollection services, params Type[] types)
        {
            foreach (var type in types)
            {
                AddType(services, type);
            }
        }

        /// <summary>
        /// 注册指定的类型
        /// </summary>
        /// <param name="services"></param>
        /// <param name="type"></param>
        public abstract void AddType(IServiceCollection services, Type type);
    }
}
