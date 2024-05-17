using Assistant.model;
using Assistant.view;
using System.Windows;
namespace Assistant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPage());
        }
    }
}