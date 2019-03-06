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
    /// Interaction logic for BubbleLabelClick.xaml
    /// </summary>
    public partial class BubbleLabelClick : Window
    {
        public BubbleLabelClick()
        {
            InitializeComponent();
        }

        int _eventCounter = 0;
        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            _eventCounter++;
            string message = "#" + _eventCounter.ToString() + ":\r\n" +
                " Sender: " + sender.ToString() + "\r\n" +
                " Source: " + e.Source + "\r\n" +
                " Original Source: " + e.OriginalSource;
            lstMessage.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            //_eventCounter = 0;
            //lstMessage.Items.Clear();
            lstMessage.Items.Add("aa");
        }
    }

    
}
