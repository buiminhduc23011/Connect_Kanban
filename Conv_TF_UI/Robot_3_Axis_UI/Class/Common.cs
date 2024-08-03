using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Controls;

namespace Conv_TF_UI.Class
{
    public static class Common
    {
        public static string PathSetting = "scnn.ini";
        public static string PathHistory = "History.json";
        public static string PathList_Error = "List_Error.ini";
        public static string PathBoxC1 = "BoxC1.log";
        public static string PathBoxC2 = "BoxC2.log";
        public static string GetMacAddress()
        {
            string macAddress = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && !nic.Description.ToLower().Contains("virtual") && !nic.Description.ToLower().Contains("pseudo"))
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // Check if it's a Wi-Fi interface
                    {
                        byte[] macBytes = nic.GetPhysicalAddress().GetAddressBytes();
                        macAddress = string.Join(":", macBytes.Select(b => b.ToString("X2")));
                        break;
                    }

                }
            }
            return macAddress;
        }
        public static string Port_QR_1;
        public static string IP_Robot_1;
        public static int Port_Robot_1;
        public static string ID_Robot_1;
        //
        public static string Port_QR_2;
        public static string IP_Robot_2;
        public static int Port_Robot_2;
        public static string ID_Robot_2;
        //
        public static string IP_PLC;
        public static int Port_PLC;
        //
        public static string IP_Server;
        public static int Port_Server;
        //
        public static string DataQR1;
        public static string DataQR1_;
        public static string DataQR2;
        public static string DataQR2_;


        public static void Init()
        {
            string filePath = PathSetting;
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);
                Port_QR_1 = (string)jsonObject["Port_QR_1"];
                IP_Robot_1 = (string)jsonObject["IP_Robot_1"];
                Port_Robot_1 = int.Parse(jsonObject["Port_Port_1"].ToString());
                ID_Robot_1 = (string)jsonObject["IDUR1"];
                //
                Port_QR_2 = (string)jsonObject["Port_QR_2"];
                IP_Robot_2 = (string)jsonObject["IP_Robot_2"];
                Port_Robot_2 = int.Parse(jsonObject["Port_Port_2"].ToString());
                ID_Robot_2 = (string)jsonObject["IDUR2"];
                //
                IP_PLC = (string)jsonObject["IP_PLC"];
                Port_PLC = int.Parse(jsonObject["Port_PLC"].ToString());
                //
                IP_Server = (string)jsonObject["IP_Server"];
                Port_Server = int.Parse(jsonObject["Port_Server"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
