using easily.framework.core.DependencyInjections;
using easily.framework.core.Tenants.Accessors;
using easily.framework.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Tenants
{
    /// <summary>
    /// 当前租户
    /// </summary>
    public class CurrentTenant<T> : ICurrentTenant<T>, ITransientDependency
    {
        private readonly ICurrentTenantAccessor<T> _currentTenantAccessor;

        public CurrentTenant(ICurrentTenantAccessor<T> currentTenantAccessor)
        {
            _currentTenantAccessor = currentTenantAccessor;
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsAvailable => Id != null && Id.Equals(default(T));

        /// <summary>
        /// 当前租户ID
        /// </summary>
        public T? Id => _currentTenantAccessor.Current == null ? default : _currentTenantAccessor.Current.Id;

        /// <summary>
        /// 租户名称
        /// </summary>
        public string? Name => _currentTenantAccessor.Current?.TenantName ?? string.Empty;

        /// <summary>
        /// 切换租户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDisposable Change(T id, string? name = null)
        {
            // 先保存当前租户信息
            var parentTenant = _currentTenantAccessor.Current;

            // 切换为新的租户
            _currentTenantAccessor.Current = new TenantBasicInfo<T>() { Id = id, TenantName = name };

            // 当新租户结束（回收）时，还原租户信息
            return new DisposeAction(() =>
            {
                _currentTenantAccessor.Current = parentTenant;
            });
        }
    }
}
