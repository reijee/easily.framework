using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.autofac.Extensions
{
    public static class AutofacServiceCollectionExtensions
    {
        public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            return hostBuilder;
        }
    }
}
