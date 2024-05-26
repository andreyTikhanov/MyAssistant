using Assistant.view.Pages;
using Assistant.view.Pages.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assistant.view
{
    
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            AddNotePage addNotePage = new AddNotePage();
            NavigationService.Navigate(addNotePage);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewCategories());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewForEditCategory());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteCategory());
        }
    }
}
