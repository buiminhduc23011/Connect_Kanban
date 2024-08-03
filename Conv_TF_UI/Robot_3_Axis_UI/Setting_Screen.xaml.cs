using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.IO;
using System.IO.Ports;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Xml.Linq;
using Conv_TF_UI.Class;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Setting_Screen.xaml
    /// </summary>
    public partial class Setting_Screen : UserControl
    {
        private DispatcherTimer timer;
        Update_Screen ud = new Update_Screen();
        PLC plc = new PLC();

        public Setting_Screen()
        {
            InitializeComponent();
            Loaded += Setting_Screen_Loaded;
            Unloaded += Setting_Screen_Unloaded;
        }

        private void Setting_Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Setting_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
            //
            txb_Port_1.Text = Common.Port_QR_1;
            txb_Ip_Robot_1.Text = Common.IP_Robot_1;
            txb_Port_Robot_1.Text = Common.Port_Robot_1.ToString();
            //
            txb_Port_2.Text = Common.Port_QR_2;
            txb_Ip_Robot_2.Text = Common.IP_Robot_2;
            txb_Port_Robot_2.Text = Common.Port_Robot_2.ToString();
            //
            txb_IP_PLC.Text = Common.IP_PLC;
            txb_Port_PLC.Text = Common.Port_PLC.ToString();
            //
            txb_IP_Server.Text = Common.IP_Server;
            txb_Port_Server.Text = Common.Port_Server.ToString();
            //
            txb_Name_UR1.Text = Common.ID_Robot_1;
            txb_Name_UR2.Text = Common.ID_Robot_2;
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
            ud.bt_Isconnect(S_PLC, PLC.Isconnect);
            ud.bt_Isconnect(S_Server, MainWindow.ConnectSocket);
            ud.bt_Isconnect(S_QR1, MainWindow.isSerialPort1Initialized);
            ud.bt_Isconnect(S_QR2, MainWindow.isSerialPort2Initialized);
            ud.bt_Isconnect(S_UR1, MainWindow.Ur1_Connected);
            ud.bt_Isconnect(S_UR2, MainWindow.Ur2_Connected);
            ud.bt_Blue(Off_Coi, IPLC.OFF_Buzzer, false);
            if (MainWindow.Ur1_Connected == true)
            {
                txb_Data_Ur1.Text = Data.Ur1.Coditon_Ur.ToString() + "/" + Data.Ur1.Mode_Product.ToString() + "/" + Data.Ur1.Ur_Control.ToString() + "/" + IPLC.Codition_RB1.ToString();
            }
            if (MainWindow.Ur2_Connected == true)
            {
                txb_Data_Ur2.Text = Data.Ur2.Coditon_Ur.ToString() + "/" + Data.Ur2.Mode_Product.ToString() + "/" + Data.Ur2.Ur_Control.ToString() + "/" + "1";
            }
        }

        private void bt_Save_Click(object sender, RoutedEventArgs e)
        {
            object data_Setting = new
            {
                Port_QR_1 = txb_Port_1.Text,
                IP_Robot_1 = txb_Ip_Robot_1.Text,
                Port_Port_1 = txb_Port_Robot_1.Text,
                IDUR1 = txb_Name_UR1.Text,
                //
                Port_QR_2 = txb_Port_2.Text,
                IP_Robot_2 = txb_Ip_Robot_2.Text,
                Port_Port_2 = txb_Port_Robot_2.Text,
                IDUR2 = txb_Name_UR2.Text,
                //
                IP_PLC = txb_IP_PLC.Text,
                Port_PLC = txb_Port_PLC.Text,
                //
                IP_Server = txb_IP_Server.Text,
                Port_Server = txb_Port_Server.Text,
            };
            string json = System.Text.Json.JsonSerializer.Serialize(data_Setting);
            File.WriteAllText(Common.PathSetting, json);
            MessageBox.Show("Đã Lưu Hoàn Thành");
        }

        private void bt_Off_Buzzer(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object>
                        {
                            { "OFF_Buzzer", !IPLC.OFF_Buzzer }
                        };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
    }
}
