using easily.framework.core.test.DependencyInjections;
using Microsoft.AspNetCore.Mvc;

namespace easily.framework.webapi.Controllers.Test
{
    public class AutofacController : TestControllerBase
    {
        public IDependencyInjectionTest InjectionTest { get; set; }
        public IDependencyAttributeTest AttributeTest { get; set; }

        [HttpGet]
        public async Task<bool> Test()
        {
            await InjectionTest.PrintAsync("【普通】：依赖注入输出的内容");
            await AttributeTest.PrintAsync("【特性】：依赖注入输出的内容");
            return true;
        }
    }
}
