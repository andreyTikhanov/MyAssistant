using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    public partial class AddCategoryAndNote : Page
    {
        SQLiteAssistantRepository _repository = new SQLiteAssistantRepository();
        public AddCategoryAndNote()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        public void Save()
        {
            if (tbTitleCategory.Text == "" || tbTitleNote.Text == "" || tbDescriptionNote.Text == "")
            {
                lbTitleCategory.Content = "Не все поля заполнены";
                return;
            }
            Category category = new Category();
            category.Title = tbTitleCategory.Text;
            _repository.AddCategory(category);
            category = _repository.GetCategory(category.Title);
            Note note = new Note();
            note.Title = tbTitleNote.Text;
            note.Description = tbDescriptionNote.Text;
            note.Id_category = category.Id;
            _repository.AddNote(note);
            lbTitleCategory.Content = "Заметка успешно сохранена";
            NavigationService.GoBack();
        }
    }
}
