using easily.framework.core.Reflections;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Bootstrappers
{
    /// <summary>
    /// 启动器上下文
    /// </summary>
    public class BootstrapperContext
    {
        public BootstrapperContext(IHostBuilder hostBuilder, IAssemblyFinder assemblyFinder) 
        {
            HostBuilder = hostBuilder;
            AssemblyFinder = assemblyFinder;
        }

        public IHostBuilder HostBuilder { get; }

        public IAssemblyFinder AssemblyFinder { get; }
    }
}
