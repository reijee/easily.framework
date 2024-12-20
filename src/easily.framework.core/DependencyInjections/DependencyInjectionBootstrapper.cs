using easily.framework.core.Bootstrappers;
using easily.framework.core.Loggers;
using easily.framework.core.Reflections;
using easily.framework.core.Tenants;
using easily.framework.core.Tenants.Accessors;
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
    /// <summary>
    /// 依赖注入启动器
    /// </summary>
    public class DependencyInjectionBootstrapper : IBootstrapper
    {
        public int SortNum => 10;

        public bool Enabled => true;

        public Action Register(BootstrapperContext bootstrapperContext)
        {
            bootstrapperContext.HostBuilder.ConfigureServices((context, services) =>
            {
                DefaultDependencyInjectionRegistrar defaultDependencyInjectionRegistrar = new DefaultDependencyInjectionRegistrar();

                var assemblies = bootstrapperContext.AssemblyFinder.Find(AssemblyFinderOption.DefaultOption);
                foreach (var assembly in assemblies)
                {
                    defaultDependencyInjectionRegistrar.AddAssembly(services, assembly);
                }
            });
            return () => { };
        }
    }
}
