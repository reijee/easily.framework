using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.test.DependencyInjections
{
    public class DependencyInjectionTest : IDependencyInjectionTest
    {
        private ILogger<DependencyInjectionTest> _logger;

        public DependencyInjectionTest(ILogger<DependencyInjectionTest> logger)
        {
            _logger = logger;
            _logger.LogInformation("DependencyInjectionTest created!");
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
