using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    public partial class ViewCategories : Page
    {
        SQLiteAssistantRepository? _repository;
        List<Category> _categories;

        public ViewCategories()
        {
            _repository = new SQLiteAssistantRepository();
            InitializeComponent();
            LoadCategories();
           
            
        }

        public void LoadCategories()
        {
            List<Category> categories = _repository.GetAllCategories();
            lbTitleCategory.ItemsSource = categories.ToList();
        }
        

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbTitleCategory.SelectedItem as Category;
            if (selectedCategory != null)
            {
                NavigationService.Navigate(new ViewTitleNotes(selectedCategory));
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
