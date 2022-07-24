namespace DependencyInjection;

/// <summary>
/// Class that describes a service.
/// </summary>
public class ServiceDescriptor
{
    /// <summary>
    /// The lifetime of the service.
    /// </summary>
    public ServiceLifetime ServiceLifetime { get; }

    /// <summary>
    /// An instance of the service of type <see cref="ServiceType"/>.
    /// </summary>
    public object ImplementationInstance { get; internal set; }

    /// <summary>
    /// The type of the implementation.
    /// </summary>
    public Type ImplementationType { get; }

    /// <summary>
    /// The type of the service.
    /// </summary>
    public Type ServiceType { get; }

    public ServiceDescriptor(object implementation, ServiceLifetime serviceLifetime)
    {
        if (implementation == null)
        {
            throw new ArgumentNullException(nameof(implementation));
        }
        
        ServiceType = implementation.GetType();
        ImplementationInstance = implementation;
        ServiceLifetime = serviceLifetime;
    }

    public ServiceDescriptor(Type serviceType, ServiceLifetime serviceLifetime)
    {
        if (serviceType == null)
        {
            throw new ArgumentNullException(nameof(serviceType));
        }
        
        ServiceType = serviceType;
        ServiceLifetime = serviceLifetime;
    }

    public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
    {
        if (serviceType == null)
        {
            throw new ArgumentNullException(nameof(serviceType));
        }

        if (implementationType == null)
        {
            throw new ArgumentNullException(nameof(implementationType));
        }

        ServiceLifetime = serviceLifetime;
        ServiceType = serviceType;
        ImplementationType = implementationType;
    }
}
