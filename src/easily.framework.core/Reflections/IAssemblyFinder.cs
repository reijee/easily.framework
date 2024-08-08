using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Reflections
{
    public interface IAssemblyFinder
    {
        /// <summary>
        /// 查找程序集列表
        /// </summary>
        List<Assembly> Find(AssemblyFinderOption option);
    }
}
