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
    /// Gets a registered service of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public TService GetService<TService>()
    {
        serviceDescriptors.TryGetValue(typeof(TService), out var serviceDescriptor);

        if (serviceDescriptor == null)
        {
            throw new InvalidOperationException($"Service of type `{typeof(TService)}` is not registered.");
        }

        if (serviceDescriptor.ServiceLifetime == ServiceLifetime.Singleton
            && serviceDescriptor.ImplementationInstance != null)
        {
            return (TService)serviceDescriptor.ImplementationInstance;
        }

        return default;
    }
}
