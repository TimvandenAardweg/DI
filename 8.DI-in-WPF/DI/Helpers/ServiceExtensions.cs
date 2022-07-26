using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIApp.Helpers;

internal static class ServiceExtensions
{
    public static void AddFormFactory<TForm>(this IServiceCollection services)
        where TForm : class
    {
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
        services.AddSingleton<IGenericFactory<TForm>, GenericFactory<TForm>>();
    }
}