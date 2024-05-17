using Assistant.model;
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

namespace Assistant.view.Pages
{
    public partial class ViewCategories : Page
    {
        SQLiteAssistantRepository _repository;
        public ViewCategories()
        {
            _repository = new SQLiteAssistantRepository();
            InitializeComponent();
            LoadCategories();
        }
        public void LoadCategories()
        {
            List<Category> categories = _repository.GetAllCategories();
            lbTitleCategory.ItemsSource = categories;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbTitleCategory.SelectedItem as Category;
            if (selectedCategory != null)
            {
             
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
