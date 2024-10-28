using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.tools
{
    /// <summary>
    /// 可回收的Action类
    /// 主要利用回收资源（Dispose方法）时执行Action内容
    /// </summary>
    public class DisposeAction : IDisposable
    {
        private readonly Action _action;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="action">回收资源（Dispose方法）时执行Action内容</param>
        public DisposeAction([NotNull] Action action)
        {
            _action = action;
        }

        /// <summary>
        /// 回收资源（Dispose方法）
        /// </summary>
        public void Dispose()
        {
            _action();
        }
    }
}
