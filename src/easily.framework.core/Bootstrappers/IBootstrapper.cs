using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Bootstrappers
{
    /// <summary>
    /// 启动器接口
    /// </summary>
    public interface IBootstrapper
    {
        /// <summary>
        /// 排序号
        /// </summary>
        int SortNum { get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 注册服务,该操作在启动开始时执行,如果需要延迟执行某些操作,可在返回的Action中执行,它将在启动最后执行
        /// </summary>
        /// <param name="context">启动器上下文</param>
        Action Register(BootstrapperContext context);
    }
}
