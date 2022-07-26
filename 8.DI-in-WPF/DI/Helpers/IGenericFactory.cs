namespace DIApp.Helpers
{
    public interface IGenericFactory<T>
    {
        T Create();
    }
}