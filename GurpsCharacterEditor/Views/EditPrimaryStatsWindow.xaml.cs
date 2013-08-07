﻿using System.Windows;
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

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
