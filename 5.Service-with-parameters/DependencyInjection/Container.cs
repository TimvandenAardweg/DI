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
    /// <exception cref="Exception">
    /// Thrown when the implementation type is <c>null</c>, an abstract class or an interface.
    /// </exception>
    public TService GetService<TService>()
    {
        return (TService)GetService(typeof(TService));
    }

    private object GetService(Type serviceType)
    {
        serviceDescriptors.TryGetValue(serviceType, out var serviceDescriptor);

        if (serviceDescriptor == null)
        {
            throw new InvalidOperationException($"Service of type `{serviceType}` is not registered.");
        }

        if (serviceDescriptor.ImplementationInstance != null)
        {
            return serviceDescriptor.ImplementationInstance;
        }

        Type implementationType = serviceDescriptor.ImplementationType ?? serviceDescriptor.ServiceType;
        if (implementationType == null || implementationType.IsAbstract || implementationType.IsInterface)
        {
            throw new Exception("Cannot instantiate null, abstract class or interface type.");
        }

        var constructorInfo = implementationType.GetConstructors().First(); // just take the first one for demo purposes
        var parameters = constructorInfo
            .GetParameters()
            .Select(param => GetService(param.ParameterType))
            .ToArray();

        var implementation = Activator.CreateInstance(implementationType, parameters);

        if (serviceDescriptor.ServiceLifetime == ServiceLifetime.Singleton)
        {
            serviceDescriptor.ImplementationInstance = implementation;
        }

        return implementation;
    }
}
