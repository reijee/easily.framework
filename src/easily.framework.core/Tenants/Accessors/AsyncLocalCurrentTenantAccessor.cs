﻿using easily.framework.core.DependencyInjections;
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
    public class AsyncLocalCurrentTenantAccessor<T>: ICurrentTenantAccessor<T>, ISingletonDependency
    {
        /// <summary>
        /// 静态对象，用于注入，当然也可以直接访问
        /// </summary>
        public static AsyncLocalCurrentTenantAccessor<T> Instance { get; } = new();

        /// <summary>
        /// AsyncLocal存储
        /// </summary>
        private readonly AsyncLocal<EasilyTenantInfo<T>?> _currentStore;

        /// <summary>
        /// 构造方法
        /// </summary>
        public AsyncLocalCurrentTenantAccessor()
        {
            _currentStore = new AsyncLocal<EasilyTenantInfo<T>?>();
        }

        /// <summary>
        /// 当前租户
        /// </summary>
        public EasilyTenantInfo<T>? Current
        {
            get => _currentStore.Value;
            set => _currentStore.Value = value;
        }
    }
}
