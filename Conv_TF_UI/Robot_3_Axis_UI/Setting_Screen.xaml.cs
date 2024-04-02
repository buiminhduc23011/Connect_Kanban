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

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Setting_Screen.xaml
    /// </summary>
    public partial class Setting_Screen : UserControl
    {
        Path Path = new Path();
        public Setting_Screen()
        {
            InitializeComponent();
        }
        private void Setting_Screen_Loaded(object sender, RoutedEventArgs e)
        {
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
        }
        private void bt_Save_Click(object sender, RoutedEventArgs e)
        {
            object data_Setting = new
            {
                Port_QR_1 = txb_Port_1.Text,
                IP_Robot_1 = txb_Ip_Robot_1.Text,
                Port_Port_1 = txb_Port_Robot_1.Text,
                //
                Port_QR_2 = txb_Port_2.Text,
                IP_Robot_2 = txb_Ip_Robot_2.Text,
                Port_Port_2 = txb_Port_Robot_2.Text,
                //
                IP_PLC = txb_IP_PLC.Text,
                Port_PLC = txb_Port_PLC.Text,
                //
                IP_Server = txb_IP_Server.Text,
                Port_Server = txb_Port_Server.Text,
            };
            string json = JsonSerializer.Serialize(data_Setting);
            File.WriteAllText(Path.Setting, json);
            MessageBox.Show("Đã Lưu Hoàn Thành");
        }
        private void bt_Off_Buzzer(object sender, RoutedEventArgs e)
        {

        }
    }
}
