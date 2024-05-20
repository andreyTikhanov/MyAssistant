using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
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
            Category selectedCategory = lbTitleCategory.SelectedItem as Category;
            if (selectedCategory == null)
            {
                lbCategory.Content = "Вы не выбрали категорию категорию";
            }
            if (selectedCategory != null)
            {
                NavigationService.Navigate(new ViewNotesForEdit(selectedCategory));
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEditCategory_Click(object sender, RoutedEventArgs e)
        {
            Category category = lbTitleCategory.SelectedItem as Category;
            if (category != null)
            {
                tbCategory.Visibility = Visibility.Visible;
                tbCategory.Text = "Введите новое название категории";
                btnEditCategory.Visibility = Visibility.Hidden;
                btnSaveCategory.Visibility = Visibility.Visible;
                btnSaveCategory.Content = "Сохранить";
            }
        }
        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && !textBox.IsKeyboardFocused)
            {
                textBox.Clear();
                e.Handled = true;
                textBox.Focus();
            }
        }

        private void btnSaveCategory_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbTitleCategory.SelectedItem as Category;
            if (tbCategory.Text == "") return;
            selectedCategory.Title = tbCategory.Text;
            _repository.UpdateCategory(selectedCategory);
            tbCategory.Text = "Категория изменена";
        }
    }
}
