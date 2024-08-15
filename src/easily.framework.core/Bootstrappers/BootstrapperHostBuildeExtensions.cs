using easily.framework.core.Reflections;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Text;

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
        public static IHostBuilder UseBootstrapper(this IHostBuilder hostBuilder)
        {
            // 创建 IAssemblyFinder
            IAssemblyFinder assemblyFinder = new AppDomainAssemblyFinder();
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            });

            // 查询所有启动器
            var assemblies = assemblyFinder.Find(AssemblyFinderOption.DefaultOption);
            List<IBootstrapper?> bootstrappers = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IBootstrapper).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .Select(t=> Activator.CreateInstance(t) as IBootstrapper)
                .Where(t=> t != null && t.Enabled == true).OrderBy(t=>t.SortNum).ToList();

            // 遍历启动器
            var actions = new List<Action>();
            var context = new BootstrapperContext(hostBuilder, assemblyFinder);
            bootstrappers.ForEach(instance => {
                actions.Add(instance?.Register(context));
            });

            // 延迟启动
            actions.ForEach(action => action?.Invoke());

            // 返回
            return hostBuilder;
        }
    }
}
