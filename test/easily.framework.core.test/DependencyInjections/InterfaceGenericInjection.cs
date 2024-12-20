using Microsoft.Extensions.Logging;

namespace easily.framework.core.test.DependencyInjections
{
    public interface IInterfaceGenericInjection<T>
    {
        T Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        void Display();
    }

    public class InterfaceGenericInjectionIns<T> : IInterfaceGenericInjection<T>//, ITransientDependency
    {
        private readonly ILogger<InterfaceGenericInjectionIns<T>> _logger;

        public InterfaceGenericInjectionIns(ILogger<InterfaceGenericInjectionIns<T>> logger)
        {
            _logger = logger;
        }

        public T Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Display()
        {
            string str = $"{nameof(GenericInjectionModel<T>)}, Id={Id}, Name={Name}, Description={Description}";
            _logger.LogInformation(str);
        }
    }
}
