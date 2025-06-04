using easily.framework.core.test.DependencyInjections;
using Microsoft.AspNetCore.Mvc;

namespace easily.framework.webapi.Controllers.Test
{
    public class AutofacController : TestControllerBase
    {
        public required IDependencyInjectionTest InjectionTest { get; set; }
        public required IDependencyAttributeTest AttributeTest { get; set; }

        [HttpGet]
        public async Task<bool> Test()
        {
            await InjectionTest.PrintAsync("【普通】：依赖注入输出的内容");
            await AttributeTest.PrintAsync("【特性】：依赖注入输出的内容");
            return true;
        }
    }
}
