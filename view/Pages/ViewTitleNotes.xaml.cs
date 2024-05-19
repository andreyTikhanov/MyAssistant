using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    public partial class ViewTitleNotes : Page
    {
        SQLiteAssistantRepository _repository;
        public ViewTitleNotes()
        {
            InitializeComponent();
        }

        public ViewTitleNotes(Category category)
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
            if (selectedNote == null) lbTitle.Content = "Вы не выбрали заметку";
            if (selectedNote != null)  
            {
                NavigationService.Navigate(new ViewDescriptionNote(selectedNote));
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
