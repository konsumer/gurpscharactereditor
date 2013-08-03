using System.Collections.Generic;
using System.ComponentModel;

namespace GurpsCharacterEditor.ViewModels
{
    // Base class for the viewmodels, which implements the INotifyPropertyChanged interface.
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Dictionary which holds information about which property is dependent on which. This is used by the
        // property change notification system.
        //
        // Key: a property of the viewmodel.
        // Value: an array of properties, which are dependent on the property.
        protected Dictionary<string, string[]> PropertyDependencyMap = new Dictionary<string, string[]>();

        // Notify registered listeners that a change has happened. Used when setting property values.
        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                // Notify property change
                PropertyChanged(this, new PropertyChangedEventArgs(property));

                // Notify dependencies, if any
                if (PropertyDependencyMap.ContainsKey(property))
                    foreach (string dependencyProperty in PropertyDependencyMap[property])
                        NotifyPropertyChanged(dependencyProperty);
            }
        }
    }
}
