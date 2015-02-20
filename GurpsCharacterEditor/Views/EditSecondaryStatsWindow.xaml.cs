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

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
