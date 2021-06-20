using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModernUI.MVVM.ViewModel;

namespace ModernUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();

            // Subscribe to the RequestClose event
            // Close the window when the ViewModel asks to be closed.
            //mainViewModel.RequestClose += delegate (object sender, EventArgs args) { this.Close(); };
            mainViewModel.RequestClose += delegate { window.Close(); };

            // Allow all controls in the window to bind to the ViewModel by setting the
            // DataContext, which propagates down the element tree.
            window.DataContext = mainViewModel;
            window.Show();
        }

    }
 
}
