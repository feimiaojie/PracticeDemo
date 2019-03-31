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
    /// AnimationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationWindow : Window
    {
        public AnimationWindow()
        {
            InitializeComponent();
            listbox.ItemsSource = GetNumber();
        }

        private List<int> GetNumber()
        {
            List<int> listNumber = new List<int>();
            for (int i = 0; i < 99; i++)
            {
                listNumber.Add(i);
            }
            return listNumber;
        }
    }
}
