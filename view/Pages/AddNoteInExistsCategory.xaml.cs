using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view
{
    public partial class AddNoteInExistsCategory : Page
    {
        SQLiteAssistantRepository _repository = new SQLiteAssistantRepository();
        Category category;
        public AddNoteInExistsCategory()
        {
            InitializeComponent();
        }

        public AddNoteInExistsCategory(Category category)
        {
            InitializeComponent();
            this.category = category;
            lbTitleCategory.Content= category.Title;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitleNote.Text == "" || tbDescriptionNote.Text == "") return;
            Note note = new Note();
            note.Title = tbTitleNote.Text;
            note.Description = tbDescriptionNote.Text;
            note.Id_category= category.Id;
            _repository.AddNote(note);
            lbTitleCategory.Content = "Заметка успешно добавлена";
            tbTitleNote.Text = "";
            tbDescriptionNote.Text = "";



        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
