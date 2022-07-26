using DependencyInjection;
using ConsoleApp.services;

var services = new ServiceCollection();

//services.RegisterSingleton(new RandomGuidGeneratorService());
//services.RegisterSingleton<RandomGuidGeneratorService>();
//services.RegisterTransient<RandomGuidGeneratorService>();
//services.RegisterTransient<IGuidPrintService, GuidPrintService>();
//services.RegisterSingleton<IGuidPrintService, GuidPrintService>();

/*
 * Register a singleton RandomGuidProvider.
 * Register a transient AnotherGuidePrintService.
 * 
 * Each time AnotherGuidPrintService is requested, it gets injected
 * the same instance of RandomGuidProvider. So the Guid will be the
 * same every time you use the print service.
 * 
 * The expected output is that for all 4 print statements, the same
 * Guid will be printed.
 */
services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
services.RegisterTransient<IGuidPrintService, AnotherGuidPrintService>(); // this service requires a RandomGuidProvider as parameter in the constructor

///*
// * Register a transient RandomGuidProvider.
// * Register a transient AnotherGuidePrintService.
// * 
// * Each time AnotherGuidPrintService is requested, it gets injected
// * a different instance of RandomGuidProvider. So the Guid will be 
// * different every time you request a new print service.
// * 
// * The expected output is that the printed Guid differs between
// * service1 and service2.
// */
//services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
//services.RegisterTransient<IGuidPrintService, AnotherGuidPrintService>(); // this service requires a RandomGuidProvider as parameter in the constructor

Container container = services.GenerateContainer();

IGuidPrintService guidService1 = container.GetService<IGuidPrintService>();
IGuidPrintService guidService2 = container.GetService<IGuidPrintService>();

guidService1.PrintGuid();
guidService1.PrintGuid();
guidService2.PrintGuid();
guidService2.PrintGuid();