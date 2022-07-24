namespace DependencyInjection;

/// <summary>
/// Collection of services.
/// </summary>
public class ServiceCollection
{
    private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

    /// <summary>
    /// Registers a new singleton service given the implementation of that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <param name="implementation">The implementation of the service.</param>
    /// <exception cref="Exception">
    /// Thrown when a service of type <typeparamref name="TService"/> has already been registered.
    /// </exception>
    public void RegisterSingleton<TService>(TService implementation) where TService : class
    {
        Type serviceType = typeof(TService);

        if (ServiceTypeIsAlreadyRegistered(serviceType))
        {
            throw new Exception($"A service of type {serviceType} has already been registered.");
        }

        var serviceDescriptor = new ServiceDescriptor(implementation, ServiceLifetime.Singleton);

        _serviceDescriptors.Add(typeof(TService), serviceDescriptor);
    }

    /// <summary>
    /// Registers a new singleton service given the type of that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <exception cref="Exception">
    /// Thrown when a service of type <typeparamref name="TService"/> has already been registered.
    /// </exception>
    public void RegisterSingleton<TService>() where TService : class
    {
        Type serviceType = typeof(TService);

        if (ServiceTypeIsAlreadyRegistered(serviceType))
        {
            throw new Exception($"A service of type {serviceType} has already been registered.");
        }

        var serviceDescriptor = new ServiceDescriptor(serviceType, ServiceLifetime.Singleton);

        _serviceDescriptors.Add(serviceType, serviceDescriptor);
    }

    /// <summary>
    /// Creates a new container that allows access to registerd services.
    /// </summary>
    /// <returns></returns>
    public Container GenerateContainer()
    {
        return new Container(_serviceDescriptors);
    }

    private bool ServiceTypeIsAlreadyRegistered(Type serviceType)
    {
        _serviceDescriptors.TryGetValue(serviceType, out var serviceDescriptor);

        if (serviceDescriptor != null)
        {
            return true;
        }

        return false;
    }
}