using DependencyInjection;
using ConsoleApp.services;

var services = new ServiceCollection();

//services.RegisterSingleton(new RandomGuidGeneratorService());
services.RegisterSingleton<RandomGuidGeneratorService>();

Container container = services.GenerateContainer();

RandomGuidGeneratorService guidService1 = container.GetService<RandomGuidGeneratorService>();
RandomGuidGeneratorService guidService2 = container.GetService<RandomGuidGeneratorService>();

Console.WriteLine(guidService1.RandomGuid);
Console.WriteLine(guidService2.RandomGuid);