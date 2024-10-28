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
    /// <typeparam name="T"></typeparam>
    public interface ICurrentTenant<T>
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// 当前租户ID
        /// </summary>
        T Id { get; }

        /// <summary>
        /// 租户名称
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// 切换租户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IDisposable Change(T id, string? name = null);
    }
}
