using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants.Accessors
{
    /// <summary>
    /// 当前租户存储存器（AsyncLocal存储）
    /// </summary>
    public class AsyncLocalCurrentTenantAccessor<T>: ICurrentTenantAccessor<T>
    {
        /// <summary>
        /// 静态对象，用于注入，当然也可以直接访问
        /// </summary>
        public static AsyncLocalCurrentTenantAccessor<T> Instance { get; } = new();

        /// <summary>
        /// AsyncLocal存储
        /// </summary>
        private readonly AsyncLocal<TenantBasicInfo<T>?> _currentStore;

        /// <summary>
        /// 构造方法
        /// </summary>
        private AsyncLocalCurrentTenantAccessor()
        {
            _currentStore = new AsyncLocal<TenantBasicInfo<T>?>();
        }

        /// <summary>
        /// 当前租户
        /// </summary>
        public TenantBasicInfo<T>? Current
        {
            get => _currentStore.Value;
            set => _currentStore.Value = value;
        }
    }
}
