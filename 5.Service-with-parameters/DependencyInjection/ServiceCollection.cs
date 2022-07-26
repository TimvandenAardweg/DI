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
        Register(implementation, ServiceLifetime.Singleton);
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
        Register<TService>(ServiceLifetime.Singleton);
    }

    /// <summary>
    /// Registers a new singleton service with a given implementation for that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <typeparam name="TImplementation">The implementation for that service.</typeparam>
    /// /// <exception cref="Exception">
    /// Thrown when a service of type <typeparamref name="TService"/> has already been registered.
    /// </exception>
    public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
    {
        Register<TService, TImplementation>(ServiceLifetime.Singleton);
    }

    /// <summary>
    /// Registeres a new transient service given the type of that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <exception cref="Exception">
    /// Thrown when a service of type <typeparamref name="TService"/> has already been registered.
    /// </exception>
    public void RegisterTransient<TService>() where TService : class
    {
        Register<TService>(ServiceLifetime.Transient);
    }

    /// <summary>
    /// Registers a new transient service with a given implementation for that service.
    /// </summary>
    /// <typeparam name="TService">The type of the service to register.</typeparam>
    /// <typeparam name="TImplementation">The implementation for that service.</typeparam>
    /// /// <exception cref="Exception">
    /// Thrown when a service of type <typeparamref name="TService"/> has already been registered.
    /// </exception>
    public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
    {
        Register<TService, TImplementation>(ServiceLifetime.Transient);
    }

    private void Register<TService>(TService implementation, ServiceLifetime serviceLifetime) where TService : class
    {
        Type serviceType = typeof(TService);

        if (ServiceTypeIsAlreadyRegistered(serviceType))
        {
            throw new Exception($"A service of type {serviceType} has already been registered.");
        }

        var serviceDescriptor = new ServiceDescriptor(implementation, serviceLifetime);

        _serviceDescriptors.Add(typeof(TService), serviceDescriptor);
    }

    private void Register<TService>(ServiceLifetime serviceLifetime) where TService : class
    {
        Type serviceType = typeof(TService);

        if (ServiceTypeIsAlreadyRegistered(serviceType))
        {
            throw new Exception($"A service of type {serviceType} has already been registered.");
        }

        var serviceDescriptor = new ServiceDescriptor(serviceType, serviceLifetime);

        _serviceDescriptors.Add(serviceType, serviceDescriptor);
    }

    private void Register<TService, TImplementation>(ServiceLifetime serviceLifetime) where TImplementation : TService
    {
        Type serviceType = typeof(TService);

        if (ServiceTypeIsAlreadyRegistered(serviceType))
        {
            throw new Exception($"A service of type {serviceType} has already been registered.");
        }

        Type implementationType = typeof(TImplementation);

        var serviceDescriptor = new ServiceDescriptor(serviceType, implementationType, serviceLifetime);

        _serviceDescriptors.Add(typeof(TService), serviceDescriptor);
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