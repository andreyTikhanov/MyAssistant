using System.Windows;

namespace Assistant.view.Windows
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }
        public bool? Result {  get; private set; }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }
    }
}
