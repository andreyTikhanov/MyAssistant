using Assistant.model;
using Assistant.view.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages.Delete
{
    public partial class DeleteCategory : Page
    {
        SQLiteAssistantRepository _repository;
        public DeleteCategory()
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbTitleCategory.SelectedItem as Category;
            if (selectedCategory == null)
            {
                lbCategory.Content = "Вы не выбрали категорию";
                return;
            }
            DialogWindow dialog = new DialogWindow();
            dialog.ShowDialog();
            
            if(dialog.Result == true)
            {
                _repository.RemoveCategory(selectedCategory);
                lbCategory.Content = "Категория удалена";
            }
            NavigationService.GoBack();
            



        }
    }
}
