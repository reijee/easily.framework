using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants
{
    /// <summary>
    /// 租户的基本信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TenantBasicInfo<T>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public T? Id { get; set; }

        /// <summary>
        /// 租户名称
        /// </summary>
        public string? TenantName { get; set; }
    }
}
