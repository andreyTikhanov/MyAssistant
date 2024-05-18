using Assistant.model;
using Assistant.view.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view
{
    public partial class AddNotePage : Page
    {
        private SQLiteAssistantRepository _repository;
      

        public AddNotePage()
        {
            InitializeComponent();
            _repository = new SQLiteAssistantRepository();
            LoadCategories();
          

            
        }
        public void LoadCategories()
        {
           List<Category> categories = _repository.GetAllCategories();
           lbCategory.ItemsSource = categories;
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbCategory.SelectedItem as Category;
            if (selectedCategory != null)
            {
                NavigationService.Navigate(new AddNoteInExistsCategory(selectedCategory));
            }
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCategoryAndNote());
        }
    }
}
