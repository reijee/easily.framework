using easily.framework.core.DependencyInjections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace easily.framework.core.test.DependencyInjections
{
    public interface IGenericInjectionTest3
    {
        Task PrintAsync();
    }

    public abstract class GenericInjectionTest3<T> : IGenericInjectionTest3
    {
        private readonly ILogger<GenericInjectionTest3<T>> _logger;

        public GenericInjectionTest3(ILogger<GenericInjectionTest3<T>> logger)
        {
            _logger = logger;
        }

        public T Id { get; set; }

        public string Name { get; set; }

        public async Task PrintAsync()
        {
            await Task.Run(() =>
            {
                string str = $"{nameof(GenericInjectionTest3<T>)}, Id={Id}, Name={Name}";
                _logger.LogInformation(str);
            });
        }
    }

    [Dependency(ServiceLifetime.Transient, IsTry = true, IsReplace = true, RegisterTypes = new[] { typeof(GenericInjectionTest3<>) })]
    public class GenericInjectionTest3Ins<T> : GenericInjectionTest3<T>
    {
        public GenericInjectionTest3Ins(ILogger<GenericInjectionTest3<T>> logger) : base(logger)
        {
        }
    }
}
