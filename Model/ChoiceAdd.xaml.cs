using Assistant.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.View
{
    /// <summary>
    /// Логика взаимодействия для ChoiceAdd.xaml
    /// </summary>
    public partial class ChoiceAdd : Page
    {
        NoteManager noteManager = new NoteManager();
        private Dictionary<string, List<Note>> notesByCategory = new Dictionary<string, List<Note>>();
        public ChoiceAdd()
        {
            InitializeComponent();
            notesByCategory=noteManager.LoadNotes();

            ShowNotes();
        }
        
        public void ShowNotes()
        {
            lbCategories.ItemsSource = notesByCategory.Keys.ToList();
        }
        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = lbCategories.SelectedItem as string;
            if (selectedCategory != null)
            {
                
            }
        }

        private void btn_AddNote_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote= new AddNote();

            NavigationService.Navigate(addNote);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = lbCategories.SelectedItem as string;
            if (selectedCategory != null)
            {
                
                AddNote addNotePage = new AddNote(selectedCategory); ;
                NavigationService?.Navigate(addNotePage);
            }
            else
            {
                MessageBox.Show("Please select a category before continuing.");
            }
        }
    }
}
