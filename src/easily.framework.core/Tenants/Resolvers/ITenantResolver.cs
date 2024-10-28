using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants.Resolvers
{
    /// <summary>
    /// 租户解析器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITenantResolver<T>
    {
        /// <summary>
        /// 解析租户ID
        /// </summary>
        /// <returns></returns>
        Task<T> ResolveTenantIdAsync();
    }
}
