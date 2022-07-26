namespace ConsoleApp.services;

internal class GuidPrintService : IGuidPrintService
{
    private readonly Guid guid;

    public GuidPrintService()
    {
        guid = Guid.NewGuid();
    }
    
    /// <summary>
    /// Prints the stored Guid.
    /// </summary>
    public void PrintGuid()
    {
        Console.WriteLine(guid);
    }
}
