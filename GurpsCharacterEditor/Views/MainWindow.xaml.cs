using System.Windows;
using GurpsCharacterEditor.ViewModels;

namespace GurpsCharacterEditor.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
