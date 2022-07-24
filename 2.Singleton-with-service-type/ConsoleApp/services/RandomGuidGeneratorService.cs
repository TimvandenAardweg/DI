namespace ConsoleApp.services;

internal class RandomGuidGeneratorService
{
    public Guid RandomGuid { get; set; } = Guid.NewGuid();
}
