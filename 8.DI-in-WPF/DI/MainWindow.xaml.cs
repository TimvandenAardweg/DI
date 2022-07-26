using DIApp;
using DIApp.Helpers;
using System.Windows;
using WpfLibrary;

namespace DI;

public partial class MainWindow : Window
{
    private readonly IDataAccess dataAccess;
    private readonly IGenericFactory<ChildWindow> factory;

    public MainWindow(IDataAccess dataAccess, IGenericFactory<ChildWindow> factory)
    {
        InitializeComponent();
        this.dataAccess = dataAccess;
        this.factory = factory;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        data.Text = dataAccess.GetData();
    }

    private void openChildForm_Click(object sender, RoutedEventArgs e)
    {
        
        factory.Create().Show();
    }
}
