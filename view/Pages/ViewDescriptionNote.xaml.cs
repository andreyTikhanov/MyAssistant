using Assistant.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assistant.view.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewDescriptionNote.xaml
    /// </summary>
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
