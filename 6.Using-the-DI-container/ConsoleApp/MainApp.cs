using ConsoleApp.services;

namespace ConsoleApp;

internal class MainApp
{
    private readonly IGuidPrintService printService;

    public MainApp(IGuidPrintService printService)
    {
        this.printService = printService;
    }
    
    public void RunApp()
    {
        printService.PrintGuid();
    }
}
