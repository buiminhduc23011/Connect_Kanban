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
    /// Interaction logic for M_Cum3.xaml
    /// </summary>
    public partial class M_Cum3 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        PLC plc = new PLC();
        public M_Cum3()
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
            // Gán giá trị cho D5 và IIPLC.D5
            update.bt_Blue(D5_0, IPLC.M640,false);
            update.bt_Blue(D5_1, IPLC.M641,false);
            update.bt_Blue(D5_2, IPLC.M642,false);
            update.bt_Blue(D5_3, IPLC.M643,false);
            update.bt_Blue(D5_4, IPLC.M644, false);
            update.bt_Blue(D5_5, IPLC.M645, false);
            update.bt_Blue(D5_6, IPLC.M646, false);
            update.bt_Blue(D5_7, IPLC.M647, false);
            update.bt_Blue(D5_8, IPLC.M648, false);
        }

        private void D5_0_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M640", !IPLC.M640 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M641", !IPLC.M641 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M642", !IPLC.M642 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_3_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M643", !IPLC.M643 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_4_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M644", !IPLC.M644 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_5_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M645", !IPLC.M645 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_6_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M646", !IPLC.M646 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_7_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M647", !IPLC.M647 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void D5_8_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object> { { "M648", !IPLC.M648 } };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
    }
}
