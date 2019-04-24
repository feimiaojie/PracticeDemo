using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// BindData.xaml 的交互逻辑
    /// </summary>
    public partial class BindData : Window, INotifyPropertyChanged
    {
        public BindData()
        {
            MyName = "aaa";

            InitializeComponent();
        }

        private string _name;
        public string MyName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MyName"));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void btnGetProduct_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (Int32.TryParse(productID.Text, out id))
            {
                try
                {
                    gridProductDetails.DataContext = StoreDB.GetProduct(id);
                }
                catch
                {
                    MessageBox.Show("Error contacting database.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Product product = gridProductDetails.DataContext as Product;

            //没实现INotifyPropertyChanged之前，更新绑定之后的对象，界面上不会修改,因为Text的默认UpdateSourceTrigger是LostFocus
            MyName = "bbbb";
        }
    }
}
