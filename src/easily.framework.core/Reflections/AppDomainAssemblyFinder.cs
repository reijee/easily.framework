using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace easily.framework.core.Reflections
{
    public class AppDomainAssemblyFinder : IAssemblyFinder
    {
        /// <summary>
        /// 已加载的程序集列表
        /// </summary>
        private Assembly[] _assemblyList = null;

        /// <summary>
        /// 查询程序集列表
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public List<Assembly> Find(AssemblyFinderOption option)
        {
            if (_assemblyList == null)
            {
                LoadAssemblies();
            }

            if (_assemblyList == null) return [];
            return _assemblyList.Where(x=> FilterAssemblyByOption(x, option)).ToList();
        }

        /// <summary>
        /// 根据查询条件过滤程序集
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        private bool FilterAssemblyByOption(Assembly assembly, AssemblyFinderOption option)
        {
            if(assembly == null) return false;
            if (!string.IsNullOrEmpty(option?.SkipPattern))
            {
                return !Regex.IsMatch(assembly.FullName, option.SkipPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }
            if (!string.IsNullOrEmpty(option?.ContainPattern))
            {
                return Regex.IsMatch(assembly.FullName, option.SkipPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }
            return true;
        }

        /// <summary>
        /// 加载所有的程序集
        /// </summary>
        private void LoadAssemblies()
        {
            var sssemblies = AppDomain.CurrentDomain.GetAssemblies();

            // 从文件中加载
            var fileList = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");
            foreach (var file in fileList) 
            {
                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(file);
                    if (IsSkipAssembly(assemblyName.Name))
                        continue;
                    if (sssemblies.Any(t => t.FullName == assemblyName.FullName))
                        continue;
                    AppDomain.CurrentDomain.Load(assemblyName);
                }
                catch
                {
                }
            }

            _assemblyList = AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        /// 判断程序集是否要加载到程序集列表
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private bool IsSkipAssembly(string assemblyName)
        {
            return false;
        }
    }
}
