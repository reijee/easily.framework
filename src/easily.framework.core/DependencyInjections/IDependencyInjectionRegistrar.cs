using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    public interface IDependencyInjectionRegistrar
    {
        void AddAssembly(IServiceCollection services, Assembly assembly);

        void AddTypes(IServiceCollection services, params Type[] types);

        void AddType(IServiceCollection services, Type type);
    }
}
