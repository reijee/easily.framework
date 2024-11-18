using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.authorizations
{
    public static class ClaimsPrincipalHelper
    {
        /// <summary>
        /// 生成用户访问令牌
        /// </summary>
        /// <param name="claimList"></param>
        /// <param name="securityKey"></param>
        /// <param name="expires"></param>
        /// <param name="issuer"></param>
        /// <param name="audience"></param>
        /// <returns></returns>
        public static string GenerateJwtToken([NotNull] IEnumerable<Claim> claimList, [NotNull] string securityKey, int expires, string issuer = null, string audience = null)
        {
            // 安全密钥
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)), SecurityAlgorithms.HmacSha256);

            // 生成Token
            var securityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claimList,
                expires: DateTime.Now.AddMinutes(expires),
                signingCredentials: creds
            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            // 返回结果
            return token;
        }

        /// <summary>
        /// 获取用户身份的声明主体
        /// </summary>
        /// <param name="claimList"></param>
        /// <param name="schemeName"></param>
        /// <returns></returns>
        public static ClaimsPrincipal GenerateClaimsPrincipal([NotNull] IEnumerable<Claim> claimList, string schemeName)
        {
            var identity = new ClaimsIdentity(claimList, schemeName);

            return new ClaimsPrincipal(identity);
        }
    }
}
