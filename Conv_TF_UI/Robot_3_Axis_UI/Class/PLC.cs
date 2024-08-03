using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Windows.Threading;
using System.Windows;
using System.Text;
using Conv_TF_UI.Class;

namespace Conv_TF_UI
{
    public class IPLC
    {
        public static bool M600 { get; set; }
        public static bool M601 { get; set; }
        public static bool M602 { get; set; }
        public static bool M603 { get; set; }
        public static bool M604 { get; set; }
        public static bool M605 { get; set; }
        public static bool M606 { get; set; }
        public static bool M607 { get; set; }
        public static bool M608 { get; set; }
        public static bool M609 { get; set; }
        public static bool M610 { get; set; }
        public static bool M611 { get; set; }
        public static bool M612 { get; set; }
        public static bool M613 { get; set; }
        public static bool M614 { get; set; }
        public static bool M615 { get; set; }
        public static bool M616 { get; set; }
        public static bool M617 { get; set; }
        public static bool M618 { get; set; }
        public static bool M619 { get; set; }
        public static bool M620 { get; set; }
        public static bool M621 { get; set; }
        public static bool M622 { get; set; }
        public static bool M623 { get; set; }
        public static bool M624 { get; set; }
        public static bool M625 { get; set; }
        public static bool M626 { get; set; }
        public static bool M627 { get; set; }
        public static bool M628 { get; set; }
        public static bool M629 { get; set; }
        public static bool M630 { get; set; }
        public static bool M631 { get; set; }
        public static bool M632 { get; set; }
        public static bool M633 { get; set; }
        public static bool M634 { get; set; }
        public static bool M635 { get; set; }
        public static bool M636 { get; set; }
        public static bool M637 { get; set; }
        public static bool M638 { get; set; }
        public static bool M639 { get; set; }
        public static bool M640 { get; set; }
        public static bool M641 { get; set; }
        public static bool M642 { get; set; }
        public static bool M643 { get; set; }
        public static bool M644 { get; set; }
        public static bool M645 { get; set; }
        public static bool M646 { get; set; }
        public static bool M647 { get; set; }
        public static bool M648 { get; set; }
        public static bool M649 { get; set; }
        public static bool M650 { get; set; }
        //
        public static bool Reset_Error { get; set; }
        public static int Mode_Run_1 { get; set; }
        public static int Mode_Run_2 { get; set; }
        //
        public static bool R_Home_1 { get; set; }
        public static bool S_Home_1 { get; set; }
        public static bool R_Home_2 { get; set; }
        public static bool S_Home_2 { get; set; }
        //
        public static bool S_AM { get; set; }
        public static bool OFF_Buzzer { get; set; }
        //
        public static int Ur_Control_1 { get; set; }
        public static int Codition_RB1 { get; set; }
        //
        public static int List_Error { get; set; }
        //
        public static bool[] X { get; set; } = new bool[100];
        public static bool[] Y { get; set; } = new bool[100];
    }
    public class PLC
    {

        public static string Ip_Port_Host;
        private DispatcherTimer timer;
        static dynamic data_;
        public static bool Isconnect = false;
        HttpClient client = new HttpClient();
        public static dynamic Data { get; set; }
        public void Start()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();

            Ip_Port_Host = Common.IP_PLC + ":" + Common.Port_PLC;
        }
        public void Stop()
        {
            try
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer = null;
            }
            catch
            {

            }
        }
        public async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string response = await client.GetStringAsync("http://" + Ip_Port_Host + "/api/data");
                data_ = JsonConvert.DeserializeObject<dynamic>(response);
                if (data_ != null)
                {
                    P_Data(data_);
                }
                Isconnect = true;
            }
            catch
            {
                Isconnect = false;
            }
        }

        private void P_Data(dynamic data)
        {
            try
            {
                IPLC.M600 = data.M600;
                IPLC.M601 = data.M601;
                IPLC.M602 = data.M602;
                IPLC.M603 = data.M603;
                IPLC.M604 = data.M604;
                IPLC.M605 = data.M605;
                IPLC.M606 = data.M606;
                IPLC.M607 = data.M607;
                IPLC.M608 = data.M608;
                IPLC.M609 = data.M609;
                IPLC.M610 = data.M610;
                IPLC.M611 = data.M611;
                IPLC.M612 = data.M612;
                IPLC.M613 = data.M613;
                IPLC.M614 = data.M614;
                IPLC.M615 = data.M615;
                IPLC.M616 = data.M616;
                IPLC.M617 = data.M617;
                IPLC.M618 = data.M618;
                IPLC.M619 = data.M619;
                IPLC.M620 = data.M620;
                IPLC.M621 = data.M621;
                IPLC.M622 = data.M622;
                IPLC.M623 = data.M623;
                IPLC.M624 = data.M624;
                IPLC.M625 = data.M625;
                IPLC.M626 = data.M626;
                IPLC.M627 = data.M627;
                IPLC.M628 = data.M628;
                IPLC.M629 = data.M629;
                IPLC.M630 = data.M630;
                IPLC.M631 = data.M631;
                IPLC.M632 = data.M632;
                IPLC.M633 = data.M633;
                IPLC.M634 = data.M634;
                IPLC.M635 = data.M635;
                IPLC.M636 = data.M636;
                IPLC.M637 = data.M637;
                IPLC.M638 = data.M638;
                IPLC.M639 = data.M639;
                IPLC.M640 = data.M640;
                IPLC.M641 = data.M641;
                IPLC.M642 = data.M642;
                IPLC.M643 = data.M643;
                IPLC.M644 = data.M644;
                IPLC.M645 = data.M645;
                IPLC.M646 = data.M646;
                IPLC.M647 = data.M647;
                IPLC.M648 = data.M648;
                IPLC.M649 = data.M649;
                IPLC.M650 = data.M650;


                //
                IPLC.Reset_Error = data.Reset_Error;
                IPLC.Mode_Run_1 = data.Mode_Run_1;
                IPLC.Mode_Run_2 = data.Mode_Run_2;
                //
                IPLC.R_Home_1 = data.R_Home_1;
                IPLC.S_Home_1 = data.S_Home_1;
                IPLC.R_Home_2 = data.R_Home_2;
                IPLC.S_Home_2 = data.S_Home_2;
                //
                IPLC.S_AM = data.S_AM;
                //
                IPLC.OFF_Buzzer = data.OFF_Buzzer;
                IPLC.Ur_Control_1 = data.Ur_Control_1;
                IPLC.Codition_RB1 = data.Codition_RB1;
                //
                IPLC.List_Error = data.List_Error;

                //
                IPLC.X = JsonConvert.DeserializeObject<bool[]>(data.X.ToString());
                IPLC.Y = JsonConvert.DeserializeObject<bool[]>(data.Y.ToString());


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public async void Write(string jsonData)
        {
            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://" + Ip_Port_Host + "/api/Control_PLC", content);
            }
            catch
            {

            }
        }
    }
}
