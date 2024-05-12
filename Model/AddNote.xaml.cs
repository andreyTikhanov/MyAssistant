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
    /// Логика взаимодействия для AddNote.xaml
    /// </summary>
    public partial class AddNote : Page
    {
        NoteManager noteManager = new NoteManager();
        private string selectedCategory;
        public AddNote() { 
            InitializeComponent();
        }

        public AddNote(string selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            tbCategory.Text = selectedCategory;
        }
        
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            string category = tbCategory.Text;
            string title = tbTitle.Text;
            string description = tbDescription.Text;

            if (string.IsNullOrEmpty(category))
            {
                tbCategory.Text = "Введите название категории";
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                tbTitle.Text = "Введите название заметки";
                return;
            }

            Note newNote = new Note(title, description);
            noteManager.AddNote(category, newNote);
            noteManager.SaveNote();

            tbCategory.Text = "";
            tbTitle.Text = "";
            tbDescription.Text = "";

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
