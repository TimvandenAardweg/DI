namespace ConsoleApp.services;

internal class RandomGuidProvider : IRandomGuidProvider
{
    private readonly Guid randomGuid = Guid.NewGuid();

    public Guid RandomGuid => randomGuid;
}
