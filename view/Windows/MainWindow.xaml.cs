
using Assistant.model;
using Assistant.view;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAssistantRepository _assistantRepository;

        public MainWindow()
        {
            _assistantRepository =new SQLiteAssistantRepository();    
            InitializeComponent();
            MainPage mainPage = new MainPage();
            MainFrame.NavigationService.Navigate(mainPage);
        }

       
    }
}