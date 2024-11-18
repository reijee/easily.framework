using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations.Authorizations
{
    public class EasilyAuthorizationPolicyProvider :DefaultAuthorizationPolicyProvider, IAuthorizationPolicyProvider
    {
        public EasilyAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }

        /// <summary>
        /// 获取指定的策略
        /// </summary>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            // 如果策略已存在，直接返回
            var policy = await base.GetPolicyAsync(policyName);
            if (policy != null) return policy;

            // 如果不存在，则生成一个新的
            var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            policyBuilder.Requirements.Add(new EasilyAuthorizationRequirement(policyName));
            return policyBuilder.Build();
        }

        /// <summary>
        /// 是否允许缓存所有策略
        /// </summary>
        public override bool AllowsCachingPolicies => true;
    }
}
