using System.Windows;
using GurpsCharacterEditor.ViewModels;

namespace GurpsCharacterEditor.Views
{
    public partial class EditPrimaryStatsWindow : Window
    {
        public EditPrimaryStatsWindow()
        {
            DataContext = new EditPrimaryStatsViewModel();
            InitializeComponent();
        }
    }
}
