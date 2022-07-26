using DIApp;
using DIApp.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfLibrary;

namespace DI;

/// <summary>
/// This class is the entry point of the WPF app.
/// It's like the Main() method of a console app.
/// </summary>
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                //services.AddTransient<ChildWindow>(); // This won't work!
                services.AddFormFactory<ChildWindow>();
                services.AddTransient<IDataAccess, DataAccess>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        // start the container
        await AppHost!.StartAsync();

        // get the startup form (i.e. MainWindow)
        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();

        // show the form
        startupForm.Show();
        
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        // close the container before we exit the app
        await AppHost!.StopAsync();
        
        base.OnExit(e);
    }
}
