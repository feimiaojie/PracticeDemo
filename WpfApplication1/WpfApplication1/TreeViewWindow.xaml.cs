using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// TreeViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewWindow : Window
    {
        public TreeViewWindow()
        {
            InitializeComponent();
            TreeCategories.ItemsSource = StoreDB.GetCategoriesAndProducts();

            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = drive;
                item.Header = drive.ToString();
                item.Items.Add("*");
                TreeFileSystem.Items.Add(item);
            }
        }

        private void TreeFileSystem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem) e.OriginalSource;
            item.Items.Clear();

            DirectoryInfo dir;
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo) item.Tag;
                dir = drive.RootDirectory;
            }
            else
            {
                dir = (DirectoryInfo) item.Tag;
            }

            foreach (var subDir in dir.GetDirectories())
            {
                TreeViewItem newItem  = new TreeViewItem();
                newItem.Tag = subDir;
                newItem.Header = subDir.ToString();
                newItem.Items.Add("*");
                item.Items.Add(newItem);
            }
        }

        private void TreeFileSystem_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
