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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for M_Cum2.xaml
    /// </summary>
    public partial class M_Cum2 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        PLC plc = new PLC();    
        public M_Cum2()
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
            catch
            {

            }
        }
        void Update_Screen()
        {

            // Gán giá trị cho D3 và IIPLC.D3
            update.bt_Blue(D3_0, IPLC.M620,false);
            update.bt_Blue(D3_1, IPLC.M621, false);
            update.bt_Blue(D3_2, IPLC.M622, false);
            update.bt_Blue(D3_3, IPLC.M623, false);
            update.bt_Blue(D3_6, IPLC.M626, false);
            update.bt_Blue(D3_7, IPLC.M627, false);
            update.bt_Blue(D3_8, IPLC.M628, false);
            update.bt_Blue(D3_9, IPLC.M629, false);

            // Gán giá trị cho D4 và IIPLC.D4
            update.bt_Blue(D4_0, IPLC.M630, false);
            update.bt_Blue(D4_1, IPLC.M631, false);
            update.bt_Blue(D4_2, IPLC.M632, false);
            update.bt_Blue(D4_3, IPLC.M633, false);
            update.bt_Blue(D4_4, IPLC.M634, false);
            update.bt_Blue(D4_5, IPLC.M635, false);
            update.bt_Blue(D4_6, IPLC.M636, false);
            update.bt_Blue(D4_7, IPLC.M637,false);
            update.bt_Blue(D4_8, IPLC.M638, false);
        }
        private void D3_0_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M620", !IPLC.M620 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D3_1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M621", !IPLC.M621 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
        private void D3_2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M622", !IPLC.M622 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
        private void D3_3_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M623", !IPLC.M624 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D3_6_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M626", !IPLC.M626 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D3_7_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M627", !IPLC.M627 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D3_8_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M628", !IPLC.M628 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D3_9_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M629", !IPLC.M629 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
        private void D4_0_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M630", !IPLC.M630 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M631", !IPLC.M631 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M632", !IPLC.M632 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_3_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M633", !IPLC.M633 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_4_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M634", !IPLC.M634 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_5_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M635", !IPLC.M635 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_6_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M636", !IPLC.M636 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_7_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M637", !IPLC.M637 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D4_8_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M638", !IPLC.M638 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
    }
}
