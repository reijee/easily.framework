using easily.framework.authorizations.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations.Authorizations
{
    public class EasilyAuthorizationHandler : AuthorizationHandler<EasilyAuthorizationRequirement>
    {
        private readonly IPermissionChecker _permissionChecker;

        public EasilyAuthorizationHandler(IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
        }

        /// <summary>
        /// 验证用户权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EasilyAuthorizationRequirement requirement)
        {
            if (context.User?.Identity == null || context.User.Identity.IsAuthenticated == false)
            {
                context.Fail();
                return;
            }

            if (await _permissionChecker.IsGrantedAsync(context.User, requirement.PermissionName))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
