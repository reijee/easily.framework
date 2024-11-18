using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.tools.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// 获取指定的值
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string? FindClaimValue([NotNull] this ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.Claims?.FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
            return claim?.Value;
        }

        /// <summary>
        /// 获取指定的值
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static int? FindClaimIntValue([NotNull] this ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.Claims?.FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
            if (claim == null || string.IsNullOrWhiteSpace(claim.Value))
            {
                return null;
            }

            if (int.TryParse(claim.Value, out int value))
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// 获取指定的值
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static Guid? FindClaimGuidValue([NotNull] this ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.Claims?.FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
            if (claim == null || string.IsNullOrWhiteSpace(claim.Value))
            {
                return null;
            }

            if (Guid.TryParse(claim.Value, out Guid guid))
            {
                return guid;
            }

            return null;
        }
    }
}
