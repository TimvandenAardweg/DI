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
    public object ImplementationInstance { get; }

    /// <summary>
    /// The type of the service.
    /// </summary>
    public Type ServiceType { get; }

    public ServiceDescriptor(object implementation, ServiceLifetime serviceLifeTime)
    {       
        ServiceType = implementation.GetType();
        ImplementationInstance = implementation;
        ServiceLifetime = serviceLifeTime;
    }
}
