using System.Windows;
using WpfLibrary;

namespace DIApp;

public partial class ChildWindow : Window
{
    public ChildWindow(IDataAccess dataAccess)
    {
        InitializeComponent();
        dataAccessInfo.Text = dataAccess.GetData();
    }
}
