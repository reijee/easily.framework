using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Bootstrappers
{
    /// <summary>
    /// 启动器扩展
    /// </summary>
    public static class BootstrapperHostBuildeExtensions
    {
        /// <summary>
        /// 添加启动器
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder AddBootstrapper(this IHostBuilder hostBuilder)
        {
            // 查询所有类型
            List<IBootstrapper?> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsAssignableFrom(typeof(IBootstrapper)) && t.IsClass && !t.IsAbstract)
                .Select(t=> Activator.CreateInstance(t) as IBootstrapper)
                .Where(t=> t != null && t.Enabled == true).OrderBy(t=>t.SortNum).ToList();

            // 遍历启动器
            var actions = new List<Action>();
            var context = new BootstrapperContext(hostBuilder);
            types.ForEach(instance => {
                actions.Add(instance?.Register(context));
            });

            // 延迟启动
            actions.ForEach(action => action?.Invoke());

            // 返回
            return hostBuilder;
        }
    }
}
