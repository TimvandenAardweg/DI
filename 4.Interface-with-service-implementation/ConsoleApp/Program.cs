using DependencyInjection;
using ConsoleApp.services;

var services = new ServiceCollection();

//services.RegisterSingleton(new RandomGuidGeneratorService());
//services.RegisterSingleton<RandomGuidGeneratorService>();
//services.RegisterTransient<RandomGuidGeneratorService>();
services.RegisterTransient<IGuidPrintService, GuidPrintService>();
//services.RegisterSingleton<IGuidPrintService, GuidPrintService>();

Container container = services.GenerateContainer();

IGuidPrintService guidService1 = container.GetService<IGuidPrintService>();
IGuidPrintService guidService2 = container.GetService<IGuidPrintService>();

guidService1.PrintGuid();
guidService1.PrintGuid();
guidService2.PrintGuid();
guidService2.PrintGuid();