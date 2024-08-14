using easily.framework.core.DependencyInjections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.test.DependencyInjections
{
    [Dependency(ServiceLifetime.Transient, IsTry = true, IsReplace = true, RegisterTypes = [typeof(IDependencyAttributeTest)])]
    internal class DependencyAttributeTest : IDependencyAttributeTest
    {
        private ILogger<DependencyAttributeTest> _logger;

        public DependencyAttributeTest(ILogger<DependencyAttributeTest> logger)
        {
            _logger = logger;
            _logger.LogInformation("DependencyAttributeTest created!");
        }

        public async Task PrintAsync(string message)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation(message);
            });
        }
    }
}
