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

namespace Assistant.view.Pages.EditNote
{
   
    public partial class ViewEditDescroptionNote : Page
    {
        SQLiteAssistantRepository _reposirory;
        Note _note;
        public ViewEditDescroptionNote()
        {
            InitializeComponent();
        }
        public ViewEditDescroptionNote(Note note)
        {
            _reposirory= new SQLiteAssistantRepository();   
            InitializeComponent();
            _note = note;
            LoadNote();

        }
        public void LoadNote()
        {
            tbTitleNote.Text = _note.Title;
            tbDescriptionNote.Text = _note.Description;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbTitleNote.Text=="" || tbDescriptionNote.Text == "")
            {
                lbNote.Content = "Вы не ввели название и описание"; return;
            }
            _note.Title = tbTitleNote.Text;
            _note.Description = tbDescriptionNote.Text;
            _reposirory.UpdateNote(_note);
            NavigationService.GoBack();
            

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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
