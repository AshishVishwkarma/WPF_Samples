using System;
using System.Windows.Input;

namespace ModernUI.Core
{
    // A simplified variation of the DelegateCommand found in the Microsoft Composition Application Library
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;  // delegate
            _canExecute = canExecute; // delegate
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Delegating the event subscription to the CommandManager.RequerySuggested event.
        // This ensures that the WPF commanding infrastructure asks all RelayCommand objects
        // if they can execute whenever it asks the built-in commands.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
