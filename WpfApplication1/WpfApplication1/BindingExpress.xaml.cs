﻿using System;
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
    /// BindingExpress.xaml 的交互逻辑
    /// </summary>
    public partial class BindingExpress : Window
    {
        public BindingExpress()
        {
            InitializeComponent();
            BindingExpression binding = txtFontSize.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = 30;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblSampleText.FontSize = 30;
        }
    }
}