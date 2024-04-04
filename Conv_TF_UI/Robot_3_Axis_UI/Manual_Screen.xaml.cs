using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Text.Json;
using System.IO;
using System.Windows.Media;
using System.Configuration;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Manual_Screen.xaml
    /// </summary>
    public partial class Manual_Screen : UserControl
    {
        M_Cum1 M1 = new M_Cum1();
        M_Cum2 M2 = new M_Cum2();
        M_Cum3 M3 = new M_Cum3();
        public Manual_Screen()
        {
            InitializeComponent();
            Loaded += Manual_Screen_Loaded;
            Unloaded += Manual_Screen_Unloaded;
        }
        private void Manual_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            bt_Cum1.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Cum2.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_CumHoanThanh.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Manual_Monitor.Children.Add(M1);
        }
        private void Manual_Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            Manual_Monitor.Children.Clear();
        }

        private void bt_Cum1_Click(object sender, RoutedEventArgs e)
        {
            bt_Cum1.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Cum2.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_CumHoanThanh.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Manual_Monitor.Children.Clear();
            Manual_Monitor.Children.Add(M1);
        }

        private void bt_Cum2_Click(object sender, RoutedEventArgs e)
        {
            bt_Cum2.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Cum1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_CumHoanThanh.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Manual_Monitor.Children.Clear();
            Manual_Monitor.Children.Add(M2);
        }

        private void bt_CumHoanThanh_Click(object sender, RoutedEventArgs e)
        {
            bt_CumHoanThanh.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Cum2.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Cum1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Manual_Monitor.Children.Clear();
            Manual_Monitor.Children.Add(M3);
        }
    }
}
