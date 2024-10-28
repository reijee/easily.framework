using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants
{
    /// <summary>
    /// 是否为多租户
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMultiTenant<T>
    {
        /// <summary>
        /// 多租户的租户ID
        /// </summary>
        T? TenantId { get; }
    }
}
