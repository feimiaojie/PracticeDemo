using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThd_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ModifyUI);
            thread.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Dispatcher.BeginInvoke((ThreadStart)delegate
                {
                    lblHello.Content = "欢迎光临WPF世界，Dispatcher";
                });
            }).Start();
        }

        private void ModifyUI()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //lblHello.Content = "欢迎光临WPF世界，Dispatcher";
            Dispatcher.Invoke(() => lblHello.Content = "欢迎光临WPF世界，Dispatcher");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Activated");
        }

        private void btnOpenWindowLayout_Click(object sender, RoutedEventArgs e)
        {
            WindowLayout layout = new WindowLayout();
            layout.Show();
        }
    }
}
