namespace DependencyInjection;

/// <summary>
/// Container for accessing registered services.
/// </summary>
public class Container
{
    private Dictionary<Type, ServiceDescriptor> serviceDescriptors;

    public Container(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
    {
        this.serviceDescriptors = serviceDescriptors;
    }

    /// <summary>
    /// Gets a registered service of type T.
    /// </summary>
    /// <typeparam name="T">The type of service.</typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the requested <typeparamref name="TService"/> is not registered.
    /// </exception>
    public TService GetService<TService>()
    {
        serviceDescriptors.TryGetValue(typeof(TService), out var serviceDescriptor);

        if (serviceDescriptor == null)
        {
            throw new InvalidOperationException($"Service of type `{typeof(TService)}` is not registered.");
        }

        if (serviceDescriptor.ImplementationInstance != null)
        {
            return (TService)serviceDescriptor.ImplementationInstance;
        }
            
        var implementation = (TService)Activator.CreateInstance(serviceDescriptor.ServiceType);

        if (serviceDescriptor.ServiceLifetime == ServiceLifetime.Singleton)
        {
            serviceDescriptor.ImplementationInstance = implementation;
        }
        
        return implementation;
    }
}
