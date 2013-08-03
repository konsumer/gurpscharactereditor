using System;
using System.Diagnostics;
using System.Windows.Input;

namespace GurpsCharacterEditor.ViewModels
{
    // This class implements the ICommand interface using delegates
    class DelegateCommand : ICommand
    {
        Action<object> execute;
        Predicate<object> canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {
        }

        public void Execute(object parameter)
        {
            Debug.Assert(execute != null);
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;
            else
                return canExecute(parameter);
        }

        public event System.EventHandler CanExecuteChanged;
    }
}
