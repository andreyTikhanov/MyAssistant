using Assistant.model;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewForEditCategory.xaml
    /// </summary>
    public partial class ViewForEditCategory : Page
    {
        SQLiteAssistantRepository _repository;
        List<Category> _categories;
        public ViewForEditCategory()
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
            Category selectedCategory=lbTitleCategory.SelectedItem as Category;
            if (selectedCategory == null)
            {
                lbCategory.Content = "Вы не выбрали категорию категорию";
            }
            if(selectedCategory != null)
            {
                NavigationService.Navigate(new ViewNotesForEdit(selectedCategory));
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Category category=lbTitleCategory.SelectedItem as Category;
            if (category != null)
            {
                
            }
        }
    }
}
