using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations.Permissions
{
    public interface IPermissionChecker
    {
        /// <summary>
        /// 验证指定的权限是否已授权
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(ClaimsPrincipal? claimsPrincipal, [NotNull] string name);
    }
}
