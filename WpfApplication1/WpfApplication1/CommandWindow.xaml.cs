using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// CommandWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommandWindow : Window
    {
        public bool isDirty = true;
        public CommandWindow()
        {
            InitializeComponent();

            //CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //binding.Executed += NewCommand_Executed;

            //this.CommandBindings.Add(binding);

        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command triggered by " +e.Source.ToString());
            e.Handled = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);
            isDirty = false;
        }

        private void SaveCommand_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(((TextBox)sender).Text);
        }

    }
}
