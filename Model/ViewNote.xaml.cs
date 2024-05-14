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

namespace Assistant.View
{
    /// <summary>
    /// Логика взаимодействия для ViewNote.xaml
    /// </summary>
    public partial class ViewNote : Page
    {
        public ViewNote()
        {
            InitializeComponent();
        }
        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
