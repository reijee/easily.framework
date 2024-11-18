using easily.framework.authorizations.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations
{
    public static class EasilyAuthorizationServiceExtensions
    {
        /// <summary>
        /// 使用自定义授权
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEasilyAuthorization(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, EasilyAuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, EasilyAuthorizationHandler>();
            return services;
        }
    }
}
