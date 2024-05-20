using Assistant.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assistant.view.Pages
{
    public partial class ViewDescriptionNote : Page
    {
        SQLiteAssistantRepository _reposirory;
        public ViewDescriptionNote()
        {
            InitializeComponent();
        }
        public ViewDescriptionNote(Note note)
        {
            _reposirory = new SQLiteAssistantRepository();
            InitializeComponent();
            LoadNote(note.Title);
        }
        public void LoadNote(string title)
        {
            Note note = _reposirory.GetNote(title);
            if (note != null)
            {
                tbDescriptionNote.Text = note.Description;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
