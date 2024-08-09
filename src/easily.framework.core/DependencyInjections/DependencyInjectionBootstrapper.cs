using easily.framework.core.Bootstrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.DependencyInjections
{
    /// <summary>
    /// 依赖注入启动器
    /// </summary>
    public class DependencyInjectionBootstrapper : IBootstrapper
    {
        public int SortNum => 10;

        public bool Enabled => true;

        public Action Register(BootstrapperContext context)
        {
            return () =>
            {

            };
        }
    }
}
