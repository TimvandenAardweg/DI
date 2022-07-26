using System.Windows;
using WpfLibrary;

namespace DI;

public partial class MainWindow : Window
{
    private readonly IDataAccess dataAccess;

    public MainWindow(IDataAccess dataAccess)
    {
        InitializeComponent();
        this.dataAccess = dataAccess;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        data.Text = dataAccess.GetData();
    }
}
