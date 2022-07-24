namespace DependencyInjection;

/// <summary>
/// Collection of services.
/// </summary>
public class ServiceCollection
{
    private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();
    
    /// <summary>
    /// Creates a new container that allows access to registerd services.
    /// </summary>
    /// <returns></returns>
    public Container GenerateContainer()
    {
        return new Container(_serviceDescriptors);
    }

    /// <summary>
    /// Registers a new singleton service given the implementation of that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <param name="implementation">The implementation of the service.</param>
    public void RegisterSingleton<TService>(TService implementation) where TService : class
    {
        var serviceDescriptor = new ServiceDescriptor(implementation, ServiceLifetime.Singleton);
        _serviceDescriptors.Add(typeof(TService), serviceDescriptor);
    }
}