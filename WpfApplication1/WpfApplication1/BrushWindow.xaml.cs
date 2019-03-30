using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for BrushWindow.xaml
    /// </summary>
    public partial class BrushWindow : Window
    {
        public BrushWindow()
        {
            InitializeComponent();
        }

        private void CmdGrow_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = 160;
            //doubleAnimation.To = 300;
            doubleAnimation.To = button.Width + 30;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            cmdGrow.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }
    }
}
