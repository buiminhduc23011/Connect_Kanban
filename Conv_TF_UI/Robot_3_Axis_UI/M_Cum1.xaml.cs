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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for M_Cum1.xaml
    /// </summary>
    public partial class M_Cum1 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        PLC plc = new PLC();

        public M_Cum1()
        {
            InitializeComponent();
            Loaded += Manual_Screen_Loaded;
            Unloaded += Manual_Screen_Unloaded;
        }

        private void Manual_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Manual_Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    Update_Screen();
                });
            }
            catch { }
        }

        void Update_Screen()
        {
            update.bt_Blue(D1_0, IPLC.M600, false);
            update.bt_Blue(D1_1, IPLC.M601, false);
            update.bt_Blue(D1_2, IPLC.M602, false);
            update.bt_Blue(D1_3, IPLC.M603, false);
            update.bt_Blue(D1_4, IPLC.M604, false);
            update.bt_Blue(D1_5, IPLC.M605, false);
            update.bt_Blue(D1_6, IPLC.M606, false);
            update.bt_Blue(D1_7, IPLC.M607, false);
            update.bt_Blue(D1_8, IPLC.M608, false);
            update.bt_Blue(D1_9, IPLC.M609, false);
            // Gán giá trị cho D2 và IPLC.D2
            update.bt_Blue(D2_0, IPLC.M610, false);
            update.bt_Blue(D2_1, IPLC.M611, false);
            update.bt_Blue(D2_2, IPLC.M612, false);
            update.bt_Blue(D2_3, IPLC.M613, false);
            update.bt_Blue(D2_4, IPLC.M614, false);
            update.bt_Blue(D2_5, IPLC.M615, false);
            update.bt_Blue(D2_6, IPLC.M616, false);
            update.bt_Blue(D2_7, IPLC.M617, false);
            update.bt_Blue(D2_8, IPLC.M618, false);
        }

        private void D1_0_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M600", !IPLC.M600 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M601", !IPLC.M601 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M602", !IPLC.M602 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_3_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M603", !IPLC.M603 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_4_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M604", !IPLC.M604 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_5_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M605", !IPLC.M605 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_6_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M606", !IPLC.M606 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_7_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M607", !IPLC.M607 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_8_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M608", !IPLC.M608 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D1_9_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M609", !IPLC.M609 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_0_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M610", !IPLC.M610 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M611", !IPLC.M611 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M612", !IPLC.M612 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_3_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M613", !IPLC.M613 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_4_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M614", !IPLC.M614 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_5_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M615", !IPLC.M615 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_6_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M616", !IPLC.M616 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_7_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M617", !IPLC.M617 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D2_8_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M618", !IPLC.M618 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
    }
}
