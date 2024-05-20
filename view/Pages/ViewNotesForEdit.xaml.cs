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
    /// Логика взаимодействия для ViewNotesForEdit.xaml
    /// </summary>
    public partial class ViewNotesForEdit : Page
    {
        Category? category;
        SQLiteAssistantRepository? _repository;
        public ViewNotesForEdit()
        {
            InitializeComponent();
        }
        public ViewNotesForEdit(Category category)
        {
            _repository = new SQLiteAssistantRepository();
            InitializeComponent();


        }

    }
}
