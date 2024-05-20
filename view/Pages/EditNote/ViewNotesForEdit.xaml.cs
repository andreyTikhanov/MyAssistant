using Assistant.model;
using Assistant.view.Pages.EditNote;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{

    public partial class ViewNotesForEdit : Page
    {
        SQLiteAssistantRepository _repository;
        Category _category;
        public ViewNotesForEdit()
        {
            InitializeComponent();
        }
        public ViewNotesForEdit(Category category)
        {
            _repository = new SQLiteAssistantRepository();
            InitializeComponent();
            LoadNotes(category);

        }
        public void LoadNotes(Category category)
        {
            List<Note> notes = _repository.SelectedCategory(category);
            lbTitleNotes.ItemsSource = notes.ToList();
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Note selectedNote = lbTitleNotes.SelectedItem as Note;
            if (selectedNote == null)
            {
                lbTitle.Content = "Вы не выбрали категорию";
                return;
            }
            NavigationService.Navigate(new ViewEditDescroptionNote(selectedNote));
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
