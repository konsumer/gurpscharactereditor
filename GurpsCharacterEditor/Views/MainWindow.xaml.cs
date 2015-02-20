using System.Windows;
using GurpsCharacterEditor.ViewModels;
using Microsoft.Windows.Controls.Ribbon;

namespace GurpsCharacterEditor.Views
{
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            DataContext = new MainViewModel(this);
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
