using easily.framework.core.DependencyInjections;
using easily.framework.core.test.DependencyInjections;
using Microsoft.AspNetCore.Mvc;

namespace easily.framework.webapi.Controllers.Test
{
    public class LazyDependencyController: TestControllerBase
    {
        private ILazyServiceProvider _lazyServiceProvider;

        private IDependencyAttributeTest _dependencyAttributeTest => _lazyServiceProvider.LazyGetRequiredService<IDependencyAttributeTest>();
        private IDependencyInjectionTest _dependencyInjectionTest => _lazyServiceProvider.LazyGetRequiredService<IDependencyInjectionTest>();

        public LazyDependencyController(ILazyServiceProvider lazyServiceProvider)
        {
            _lazyServiceProvider = lazyServiceProvider;
        }

        [HttpGet]
        public async Task<bool> Test()
        {
            await _dependencyAttributeTest.PrintAsync("特性依赖注入执行打印方法");
            return true;
        }
    }
}
