using System.Windows;
using GurpsCharacterEditor.ViewModels;

namespace GurpsCharacterEditor.Views
{
    public partial class EditSecondaryStatsWindow : Window
    {
        public EditSecondaryStatsWindow()
        {
            DataContext = new EditSecondaryStatsViewModel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
