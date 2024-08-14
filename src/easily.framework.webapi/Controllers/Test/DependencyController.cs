using easily.framework.core.test.DependencyInjections;
using Microsoft.AspNetCore.Mvc;

namespace easily.framework.webapi.Controllers.Test
{
    public class DependencyController: TestControllerBase
    {
        private IDependencyInjectionTest _dependencyTest;
        private IDependencyAttributeTest _dependencyAttributeTest;

        public DependencyController(IDependencyInjectionTest dependencyTest, 
            IDependencyAttributeTest dependencyAttributeTest)
        {
            _dependencyTest = dependencyTest;
            _dependencyAttributeTest = dependencyAttributeTest;
        }

        [HttpGet]
        public async Task<bool> Test()
        {
            await _dependencyTest.PrintAsync("【普通】：依赖注入输出的内容");
            await _dependencyAttributeTest.PrintAsync("【特性】：依赖注入输出的内容");
            return true;
        }
    }
}
