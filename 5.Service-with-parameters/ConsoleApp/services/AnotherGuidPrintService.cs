namespace ConsoleApp.services;

internal class AnotherGuidPrintService : IGuidPrintService
{
    private readonly IRandomGuidProvider randomGuidProvider;

    public AnotherGuidPrintService(IRandomGuidProvider randomGuidProvider)
    {
        this.randomGuidProvider = randomGuidProvider;
    }
    
    public void PrintGuid()
    {
        Console.WriteLine(randomGuidProvider.RandomGuid);
    }
}
