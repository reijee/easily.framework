using easily.framework.core.DependencyInjections;
using Microsoft.Extensions.Logging;

namespace easily.framework.core.test.DependencyInjections
{
    public abstract class GenericInjectionModelBase<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract void Display();
    }

    public class GenericInjectionModel<T>: GenericInjectionModelBase<T>, ITransientDependency
    {
        private readonly ILogger<GenericInjectionModel<T>> _logger;

        public GenericInjectionModel(ILogger<GenericInjectionModel<T>> logger)
        {
            _logger = logger;
        }

        public override void Display()
        {
            string str = $"{nameof(GenericInjectionModel<T>)}, Id={Id}, Name={Name}, Description={Description}";
            _logger.LogInformation(str);
        }
    }
}
