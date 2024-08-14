using easily.framework.core.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    public class DefaultDependencyInjectionRegistrar : DependencyInjectionRegistrarBase
    {
        private static ILogger _logger => StaticLoggerExtensions.CreateLogger<DefaultDependencyInjectionRegistrar>();

        /// <summary>
        /// 注册指定类型
        /// </summary>
        /// <param name="services"></param>
        /// <param name="type"></param>
        public override void AddType(IServiceCollection services, Type type)
        {
            if (IsDisableDependencyInjection(type))
            {
                return;
            }

            var dependencyAttribute = GetDependencyAttributeOrNull(type);
            var lifeTime = GetLifeTimeOrNull(type, dependencyAttribute);
            if (lifeTime == null)
            {
                return;
            }

            var exposedServices = GetExposedServiceTypes(type, dependencyAttribute);
            foreach(var exposedService in exposedServices)
            {
                _logger.LogInformation($"==============CreateServiceDescriptor：{type.FullName}，{exposedService.FullName}");
                var descriptor = CreateServiceDescriptor(type, exposedService, lifeTime.Value);

                if (dependencyAttribute?.IsReplace == true)
                {
                    services.Replace(descriptor);
                }
                else if (dependencyAttribute?.IsTry == true)
                {
                    services.TryAdd(descriptor);
                }
                else
                {
                    services.Add(descriptor);
                }
            }
        }
    }
}
