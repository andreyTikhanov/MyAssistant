using Assistant.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для ViewTitleNotes.xaml
    /// </summary>
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

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
