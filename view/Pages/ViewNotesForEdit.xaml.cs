using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewNotesForEdit.xaml
    /// </summary>
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

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEditNote_Click(object sender, RoutedEventArgs e)
        {
            Note selectedNote = lbTitleNotes.SelectedItem as Note;
            if (selectedNote != null)
            {
                tbNote.Visibility = Visibility.Visible;
                tbNote.Text = "Введите новое название заметки";
                btnEditNote.Visibility = Visibility.Hidden;
                btnSaveNote.Visibility = Visibility.Visible;
                btnSaveNote.Content = "Сохранить";
            }
        }

        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            Note selectedNote = lbTitleNotes.SelectedItem as Note;
            if (tbNote.Text == "") return;
            selectedNote.Title = tbNote.Text;
            _repository.UpdateNote(selectedNote);
            tbNote.Text = "Название заметки изменено";
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
    }
}
