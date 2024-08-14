using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    /// <summary>
    /// 延迟加载服务
    /// </summary>
    public class LazyServiceProvider : ILazyServiceProvider, ITransientDependency
    {
        #region 构造与注入
        private IServiceProvider ServiceProvider { get; }

        private ConcurrentDictionary<Type, Lazy<object?>> CachedServices { get; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="serviceProvider"></param>
        public LazyServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            CachedServices = new ConcurrentDictionary<Type, Lazy<object?>>();
            CachedServices.TryAdd(typeof(IServiceProvider), new Lazy<object?>(() => ServiceProvider));
        }
        #endregion

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T LazyGetRequiredService<T>()
        {
            return (T)LazyGetRequiredService(typeof(T));
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object LazyGetRequiredService(Type serviceType)
        {
            return CachedServices.GetOrAdd(serviceType, 
                _ => new Lazy<object?>(() => ServiceProvider.GetRequiredService(serviceType))
                ).Value!;
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T? LazyGetService<T>()
        {
            return (T?)LazyGetService(typeof(T));
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object? LazyGetService(Type serviceType)
        {
            return CachedServices.GetOrAdd(serviceType,
                _ => new Lazy<object?>(() => ServiceProvider.GetService(serviceType))
                ).Value;
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T LazyGetService<T>(T defaultValue)
        {
            return LazyGetService<T>() ?? defaultValue;
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public object LazyGetService(Type serviceType, object defaultValue)
        {
            return LazyGetService(serviceType) ?? defaultValue;
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public object LazyGetService(Type serviceType, Func<IServiceProvider, object> factory)
        {
            return CachedServices.GetOrAdd(serviceType,
                _ => new Lazy<object?>(() => factory(ServiceProvider))
                ).Value!;
        }

        /// <summary>
        /// 获取注入的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public T LazyGetService<T>(Func<IServiceProvider, object> factory)
        {
            return (T)LazyGetService(typeof(T), factory);
        }
    }
}
