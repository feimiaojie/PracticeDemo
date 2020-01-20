using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ResourceDictionaryF;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled " +e.GetType().ToString() +
                " exception was caught and ignored.");
            e.Handled = true;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                MessageBox.Show(e.Args[0]);
            }

            this.Resources = new CustomDictionary();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            StartupUri = new Uri("DataGridWindow.xaml", UriKind.Relative);
        }
    }
}
