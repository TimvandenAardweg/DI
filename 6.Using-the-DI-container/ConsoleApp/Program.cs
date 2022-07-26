using DependencyInjection;
using ConsoleApp.services;
using ConsoleApp;

var services = new ServiceCollection();

services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
services.RegisterTransient<IGuidPrintService, AnotherGuidPrintService>(); // this service requires a RandomGuidProvider as parameter in the constructor
services.RegisterSingleton<MainApp>();

Container container = services.GenerateContainer();

MainApp mainApp = container.GetService<MainApp>();

mainApp.RunApp();