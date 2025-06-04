using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.tools.StaticServices
{
    public static class StaticServiceAccessor
    {
        private static IServiceProvider? ServiceProvider;

        /// <summary>
        /// 注册静态服务访问器
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IServiceProvider UserStaticServiceAccessor(this IServiceProvider provider)
        {
            // 注册静态服务访问器
            ServiceProvider = provider;
            return provider;
        }

        public static T GetService<T>() where T : class
        {
            if (ServiceProvider == null)
            {
                throw new InvalidOperationException("StaticServiceAccessor is not initialized. Please call UserStaticServiceAccessor first.");
            }
            return ServiceProvider.GetRequiredService<T>();
        }

        public static T GetRequiredService<T>() where T : class
        {
            if (ServiceProvider == null)
            {
                throw new InvalidOperationException("StaticServiceAccessor is not initialized. Please call UserStaticServiceAccessor first.");
            }
            return ServiceProvider.GetRequiredService<T>();
        }

        public static object? GetService(Type serviceType)
        {
            if (ServiceProvider == null)
            {
                throw new InvalidOperationException("StaticServiceAccessor is not initialized. Please call UserStaticServiceAccessor first.");
            }
            return ServiceProvider.GetService(serviceType);
        }

        public static object GetRequiredService(Type serviceType)
        {
            if (ServiceProvider == null)
            {
                throw new InvalidOperationException("StaticServiceAccessor is not initialized. Please call UserStaticServiceAccessor first.");
            }
            return ServiceProvider.GetRequiredService(serviceType);
        }

        public static IServiceProvider GetServiceProvider()
        {
            if (ServiceProvider == null)
            {
                throw new InvalidOperationException("StaticServiceAccessor is not initialized. Please call UserStaticServiceAccessor first.");
            }
            return ServiceProvider;
        }
    }
}
