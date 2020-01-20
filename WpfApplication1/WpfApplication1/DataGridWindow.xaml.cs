using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApplication1
{
    /// <summary>
    /// DataGridWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public DataGridWindow()
        {
            InitializeComponent();
            this.DataContext = new DGViewModel();
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = System.Windows.Visibility.Collapsed;

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);

            ((TempData)row.Item).Details = new ObservableCollection<Child> { new Child { AA = "Dbudada", BB = "D123213" }, new Child { AA = "Dbudada", BB = "D123213" } };
            row.DetailsVisibility = System.Windows.Visibility.Visible;
        }

        public T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        //下面的方法曾让我教头烂额，感叹微软的控件封装的太牛逼了，处理起来有点变态    
        /// <summary>    
                /// 找到行明细中嵌套的控件名称    
                /// </summary>    
                /// <typeparam name="T"></typeparam>    
                /// <param name="parent"></param>    
                /// <param name="name"></param>    
                /// <returns></returns>    
        public T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i) as DependencyObject;
                    string controlName = child.GetValue(Control.NameProperty) as string;
                    if (controlName == name)
                    {
                        return child as T;
                    }
                    else
                    {
                        T result = FindVisualChildByName<T>(child, name);
                        if (result != null)
                            return result;
                    }
                }
            }
            return null;
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)sender;
            //dg.ScrollIntoView
        }

        private void DataGrid1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var offsetValue = e.VerticalOffset;
        }
    }
    public class TempData : INotifyPropertyChanged
    {
        private string key;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                NotifyPropertyChanged("Key");
            }
        }

        private string _value;
        public string Value
        {

            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        private ObservableCollection<Child> details;
        public ObservableCollection<Child> Details
        {
            get { return details; }
            set
            {
                details = value;
                NotifyPropertyChanged("Details");
            }
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

    public class Child : INotifyPropertyChanged
    {
        public string AA { get; set; }

        public string BB { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DGViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TempData> tempDatas;
        public ObservableCollection<TempData> TempDatas
        {
            get { return tempDatas; }
            set
            {
                tempDatas = value;
                NotifyPropertyChanged("TempDatas");
            }
        }
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DGViewModel()
        {
            TempDatas = new ObservableCollection<TempData>() {
                new TempData() { Key="1", Value="123213" },
                new TempData() { Key="2", Value="123213"},
                new TempData() { Key="3", Value="123213" },
                new TempData() { Key="4", Value="123213"},
                new TempData() { Key="5", Value="123213" },
                new TempData() { Key="6", Value="123213"},
                new TempData() { Key="7", Value="123213" },
                new TempData() { Key="8", Value="123213"},
                new TempData() { Key="9", Value="123213" },
                new TempData() { Key="10", Value="123213"},
                new TempData() { Key="11", Value="123213" },
                new TempData() { Key="12", Value="123213"},
                new TempData() { Key="1", Value="123213" },
                new TempData() { Key="2", Value="123213"},
                new TempData() { Key="3", Value="123213" },
                new TempData() { Key="4", Value="123213"},
                new TempData() { Key="5", Value="123213" },
                new TempData() { Key="6", Value="123213"},
                new TempData() { Key="7", Value="123213" },
                new TempData() { Key="8", Value="123213"},
                new TempData() { Key="9", Value="123213" },
                new TempData() { Key="10", Value="123213"},
                new TempData() { Key="11", Value="123213" },
                new TempData() { Key="12", Value="123213"},
                new TempData() { Key="1", Value="123213" },
                new TempData() { Key="2", Value="123213"},
                new TempData() { Key="3", Value="123213" },
                new TempData() { Key="4", Value="123213"},
                new TempData() { Key="5", Value="123213" },
                new TempData() { Key="6", Value="123213"},
                new TempData() { Key="7", Value="123213" },
                new TempData() { Key="8", Value="123213"},
                new TempData() { Key="9", Value="123213" },
                new TempData() { Key="10", Value="123213"},
                new TempData() { Key="11", Value="123213" },
                new TempData() { Key="12", Value="123213"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }


}
