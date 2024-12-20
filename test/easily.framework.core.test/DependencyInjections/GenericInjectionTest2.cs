using easily.framework.core.DependencyInjections;
using Microsoft.Extensions.Logging;

namespace easily.framework.core.test.DependencyInjections
{
    public interface IGenericInjectionTest2<T>
    {
        T Id { get; set; }

        string Name { get; set; }

        void Display();
    }

    public class GenericInjectionTest2 : IGenericInjectionTest2<int>, ITransientDependency
    {
        private readonly ILogger<GenericInjectionTest2> _logger;

        public GenericInjectionTest2(ILogger<GenericInjectionTest2> logger)
        {
            _logger = logger;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Display()
        {
            string str = $"{nameof(GenericInjectionTest2)}, Id={Id}, Name={Name}";
            _logger.LogInformation(str);
        }
    }
}
