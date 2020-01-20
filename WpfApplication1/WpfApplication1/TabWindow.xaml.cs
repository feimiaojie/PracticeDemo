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
    /// TabWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TabWindow : Window
    {
        public TabWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButton ra1 = new RadioButton();
            ra1.Name = "r1";

            RadioButton ra2 = new RadioButton();
            ra1.Name = "r1";

            wrp.Children.Add(ra1);
            wrp.Children.Add(ra2);

            var t2 = LogicalTreeHelper.FindLogicalNode(wrp, "r1");
        }
    }

    public class ContentToMarginConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(0, 0, -((ContentPresenter)value).ActualHeight, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ContentToPathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ps = new PathSegmentCollection(4);
            ContentPresenter cp = (ContentPresenter)value;
            double h = cp.ActualHeight > 10 ? 1.4 * cp.ActualHeight : 10;
            double w = cp.ActualWidth > 10 ? 1.25 * cp.ActualWidth : 10;
            ps.Add(new LineSegment(new Point(1, 0.7 * h), true));
            ps.Add(new BezierSegment(new Point(1, 0.9 * h), new Point(0.1 * h, h), new Point(0.3 * h, h), true));
            ps.Add(new LineSegment(new Point(w, h), true));
            ps.Add(new BezierSegment(new Point(w + 0.6 * h, h), new Point(w + h, 0), new Point(w + h * 1.3, 0), true));
            return ps;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
