using Assistant.model;
using Assistant.view.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Assistant.view.Pages.Delete
{
    public partial class DeleteNote : Page
    {
        SQLiteAssistantRepository _repository;
        Category _category; 
        public DeleteNote()
        {
            InitializeComponent();
        }
        public DeleteNote(Category category)
        {
            _repository = new SQLiteAssistantRepository();
            InitializeComponent();
            _category = category;
            LoadCategory(_category);

        }
        public  void LoadCategory(Category category)
        {
            List<Note> notes = _repository.SelectedCategory(category);
            lbTitleNotes.ItemsSource = notes.ToList();
        }
        private void lbCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (lbTitleNotes.SelectedItem != null)
            {
                btnDeleteClick(this, new RoutedEventArgs());
            }
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            Note selectedNote = lbTitleNotes.SelectedItem as Note;
            if (selectedNote == null) 
            {
                lbNotes.Content = "Вы не выбрали заметку"; return;
            }
            DialogWindow dialog = new DialogWindow();
            dialog.ShowDialog();

            if (dialog.Result == true)
            {
                _repository.RemoveNote(selectedNote);
                lbNotes.Content = "Заметка удалена";
            }
            
            NavigationService.GoBack();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
