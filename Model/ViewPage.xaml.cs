using Assistant.Model;
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

namespace Assistant.View
{
    /// <summary>
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        NoteManager noteManager=new NoteManager();
        private Dictionary<string, List<Note>> notesByCategory = new Dictionary<string, List<Note>>();
        public ViewPage()
        {
            InitializeComponent();
            notesByCategory = noteManager.LoadNotes();
            Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public void Show()
        {
            lbCategories.ItemsSource = notesByCategory.Keys.ToList();

        }

        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = lbCategories.SelectedItem as string;
            if (selectedCategory != null)
            {

                ViewNote viewNote = new ViewNote();
                NavigationService?.Navigate(viewNote);
            }
            else
            {
                MessageBox.Show("Please select a category before continuing.");
            }
        }
    }
}
