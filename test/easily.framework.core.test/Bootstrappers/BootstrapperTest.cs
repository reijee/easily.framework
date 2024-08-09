using easily.framework.core.Bootstrappers;
using easily.framework.core.DependencyInjections;
using easily.framework.core.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.test.Bootstrappers
{
    public class BootstrapperTest : IBootstrapper
    {
        private static ILogger _logger => StaticLoggerExtensions.CreateLogger<BootstrapperTest>();

        public int SortNum => 100;

        public bool Enabled => true;

        public Action Register(BootstrapperContext context)
        {
            _logger.LogInformation(">>>>>>> BootstrapperTest Register");

            context.HostBuilder.ConfigureServices((context, services) =>
            {
                _logger.LogInformation(">>>>>>> BootstrapperTest ConfigureServices");
            });

            return new Action(() => {
                _logger.LogInformation(">>>>>>> BootstrapperTest Action Invoke");
            });
        }
    }
}
