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
    /// Interaction logic for WindowLayout.xaml
    /// </summary>
    public partial class WindowLayout : Window
    {
        public WindowLayout()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Orientation = Orientation.Horizontal;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn4.Margin = new Thickness(5);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"长：{this.ActualWidth},宽{this.ActualHeight}");
        }
    }
}
