using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Conv_TF_UI.Class
{
    public static class Common
    {
        public static string Port_QR_1;
        public static string IP_Robot_1;
        public static int Port_Robot_1;
        //
        public static string Port_QR_2;
        public static string IP_Robot_2;
        public static int Port_Robot_2;
        //
        public static string IP_PLC;
        public static int Port_PLC;
        //
        public static string IP_Server;
        public static int Port_Server;

        public static void Init()
        {
            string filePath = "scnn.ini";
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);
                Port_QR_1 = (string)jsonObject["Port_QR_1"];
                IP_Robot_1 = (string)jsonObject["IP_Robot_1"];
                Port_Robot_1 = int.Parse(jsonObject["Port_Port_1"].ToString());
                //
                Port_QR_2 = (string)jsonObject["Port_QR_2"];
                IP_Robot_2 = (string)jsonObject["IP_Robot_2"];
                Port_Robot_2 = int.Parse(jsonObject["Port_Port_2"].ToString());
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
