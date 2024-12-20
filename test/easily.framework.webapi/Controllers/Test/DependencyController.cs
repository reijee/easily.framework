using easily.framework.core.Tenants;
using easily.framework.core.test.DependencyInjections;
using Microsoft.AspNetCore.Mvc;

namespace easily.framework.webapi.Controllers.Test
{
    public class DependencyController: TestControllerBase
    {
        private IDependencyInjectionTest _dependencyTest;
        private IDependencyAttributeTest _dependencyAttributeTest;
        private ICurrentTenant<int> _currentTenant;
        private GenericInjectionTest3<int> _genericInjectionTest3;
        private IGenericInjectionTest2<int> _genericInjectionTest2;

        public DependencyController(IDependencyInjectionTest dependencyTest,
            IDependencyAttributeTest dependencyAttributeTest,
            ICurrentTenant<int> currentTenant,
            GenericInjectionTest3<int> genericInjectionTest3,
            IGenericInjectionTest2<int> genericInjectionTest2)
        {
            _dependencyTest = dependencyTest;
            _dependencyAttributeTest = dependencyAttributeTest;
            _currentTenant = currentTenant;
            _genericInjectionTest3 = genericInjectionTest3;
            _genericInjectionTest2 = genericInjectionTest2;
        }

        [HttpGet]
        public async Task<bool> Test()
        {
            await _dependencyTest.PrintAsync("【普通】：依赖注入输出的内容");
            await _dependencyAttributeTest.PrintAsync("【特性】：依赖注入输出的内容");
            await _genericInjectionTest3.PrintAsync();
            _genericInjectionTest2.Display();
            return true;
        }
    }
}
