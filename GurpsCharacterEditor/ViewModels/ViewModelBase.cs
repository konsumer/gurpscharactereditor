using System.ComponentModel;

namespace GurpsCharacterEditor.ViewModels
{
    // Base class for the viewmodels, which implements the INotifyPropertyChanged interface.
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Notify registered listeners that a change has happened. Used when setting property values.
        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
