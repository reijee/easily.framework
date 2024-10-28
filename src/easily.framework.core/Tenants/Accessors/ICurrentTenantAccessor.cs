using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants.Accessors
{
    /// <summary>
    /// 当前租户存储存器，用于存储存当前租户信息
    /// </summary>
    public interface ICurrentTenantAccessor<T>
    {
        // 当前租户
        TenantBasicInfo<T>? Current { get; set; }
    }
}
