
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ModernUI.Core
{
    class ViewModelBase : INotifyPropertyChanged
    {
        // The INotifyPropertyChanged interface contains an event called PropertyChanged.

        // Whenever a property on a ViewModel object has a new value, it can raise the
        // PropertyChanged event to notify the WPF binding system of the new value.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // ?. (Null conditional operator for member access): used to avoid System.NullReferenceException
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            //MessageBox.Show("It should be closed!", "Message");
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
