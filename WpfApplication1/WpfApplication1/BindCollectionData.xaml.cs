using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApplication1.DB;

namespace WpfApplication1
{
    /// <summary>
    /// BindCollectionData.xaml 的交互逻辑
    /// </summary>
    public partial class BindCollectionData : Window
    {
        public BindCollectionData()
        {
            InitializeComponent();
            dtPicker.Text = "2019/8/12";
        }
        private ObservableCollection<Product> products;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            products = new ObservableCollection<Product>(StoreDB.GetProducts());
            lstProducts.ItemsSource = products;
            var a = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);

            
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            products.Remove((Product)lstProducts.SelectedItem);
        }

        private void LstProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
