using System;

namespace DIApp.Helpers;

internal class GenericFactory<T> : IGenericFactory<T>
{
    private readonly Func<T> factory;

    public GenericFactory(Func<T> factory)
    {
        this.factory = factory;
    }

    public T Create()
    {
        return factory();
    }
}
