using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Timers;
using Conv_TF_UI.Class;
using System.Windows.Threading;
using Newtonsoft.Json;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Windows.Shapes;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Auto_Screen.xaml
    /// </summary>
    /// 
    public class Box
    {
        public int STT { get; set; }
        public string BoxID{ get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
    public class BoxLog
    {
        public string BoxID { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }

    public partial class Auto_Screen : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        PLC plc = new PLC();
        public Auto_Screen()
        {

            InitializeComponent();
            Loaded += loaded;
            Unloaded += unloaded;
        }
        private void unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            {

                try
                {
                    Dispatcher.Invoke(() =>
                    {
                        Update_Error();
                        txb_Qr1.Text = Common.DataQR1_;
                        txb_Qr2.Text = Common.DataQR2_;

                    });
                    Thread.Sleep(200);
                }
                catch { }

            }
            void Update_Error()
            {
                System.DateTime dateTime = System.DateTime.Now;
                string formattedDate = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                if (!PLC.Isconnect)
                {
                    lb_Error_Status.Content = "Mất Kết Nối PLC" + "  " + formattedDate;
                    lb_Error_Status.Foreground = Brushes.Red;
                }
                else if (IPLC.List_Error > 0)
                {
                    string json = File.ReadAllText(Common.PathList_Error);
                    string[] errorArray = json.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    lb_Error_Status.Content = errorArray[IPLC.List_Error - 1].Replace("\r", "").Replace("\n", "") + "  " + formattedDate;
                    lb_Error_Status.Foreground = Brushes.Red;
                }
                else
                {
                    lb_Error_Status.Content = "Hệ Thống Không Lỗi";
                    lb_Error_Status.Foreground = Brushes.Green;
                }
                update.bt_Blue(bt_Origin_Cum1,IPLC.S_Home_1,false);
                update.bt_Blue(bt_Origin_Cum2, IPLC.S_Home_2, false);
            }

        }

        private void bt_Origin_Cum1_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object>
                        {
                            { "R_Home_1", 1 }
                        };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void bt_Origin_Cum2_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object>
                        {
                            { "R_Home_2", 1 }
                        };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }

        private void txb_Qr1_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.DateTime dateTime = System.DateTime.Now;
            string Time = dateTime.ToString("hh:mm:ss");
            string Date = dateTime.ToString("dd/MM/yyyy");
            try
            {

                string json = File.ReadAllText(Common.PathBoxC1);
                if (json.Length > 0)
                {
                    json = json.Remove(json.Length - 1);
                    json = json + "," + "{\"BoxID\": " + "\"" + txb_Qr1.Text + "\"," + "\"Time\": " + "\"" + Time + "\"," + "\"Date\": " + "\"" + Date + "\"}" + "]";
                    File.WriteAllText(Common.PathBoxC1, json);
                }
                else
                {
                    json = "[{\"BoxID\": " + "\"" + txb_Qr1.Text + "\"," + "\"Time\": " + "\"" + Time + "\"," + "\"Date\": " + "\"" + Date + "\"}" + "]";
                    File.WriteAllText(Common.PathBoxC1, json);
                }
                List<Box> items = new List<Box>();
                string List_Show = File.ReadAllText(Common.PathBoxC1);
                int index = 1;
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)

                    {
                        if((string)obj["Date"] == Date)
                        {
                            items.Add(new Box { STT = index, BoxID = (string)obj["BoxID"], Time = (string)obj["Time"] });
                            index++;
                        }    
                        
                    }
                    items.Reverse();
                    List_Box_C1.ItemsSource = items;
                }
                List<BoxLog> list = new List<BoxLog>();
                string List_Log = File.ReadAllText(Common.PathBoxC1);
                if (List_Log.Length > 0)
                {
                    JArray List = JArray.Parse(List_Log);
                    foreach (JObject obj in List)

                    {
                        if ((string)obj["Date"] == Date)
                        {
                            list.Add(new BoxLog { BoxID = (string)obj["BoxID"], Time = (string)obj["Time"], Date = (string)obj["Date"] });
                        }

                    }
                    list.Reverse();
                    string json_ = JsonConvert.SerializeObject(list);
                    File.WriteAllText(Common.PathBoxC1, json_);
                }
            }
            catch
            {
            }
        }

        private void txb_Qr2_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.DateTime dateTime = System.DateTime.Now;
            string Time = dateTime.ToString("hh:mm:ss");
            string Date = dateTime.ToString("dd/MM/yyyy");
            try
            {
                string json = File.ReadAllText(Common.PathBoxC2);
                if (json.Length > 0)
                {
                    json = json.Remove(json.Length - 1);
                    json = json + "," + "{\"BoxID\": " + "\"" + txb_Qr2.Text + "\"," + "\"Time\": " + "\"" + Time + "\"," + "\"Date\": " + "\"" + Date + "\"}" + "]";
                    File.WriteAllText(Common.PathBoxC2, json);
                }
                else
                {
                    json = "[{\"BoxID\": " + "\"" + txb_Qr2.Text + "\"," + "\"Time\": " + "\"" + Time + "\"," + "\"Date\": " + "\"" + Date + "\"}" + "]";
                    File.WriteAllText(Common.PathBoxC2, json);
                }
                List<Box> items = new List<Box>();
                string List_Show = File.ReadAllText(Common.PathBoxC2);
                int index = 1;
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)
                    {
                        if ((string)obj["Date"] == Date)
                        {
                            items.Add(new Box { STT = index, BoxID = (string)obj["BoxID"], Time = (string)obj["Time"] });
                            index++;
                        }
                    }
                    items.Reverse();
                    List_Box_C2.ItemsSource = items;
                }
                List<BoxLog> list = new List<BoxLog>();
                string List_Log = File.ReadAllText(Common.PathBoxC2);
                if (List_Log.Length > 0)
                {
                    JArray List = JArray.Parse(List_Log);
                    foreach (JObject obj in List)

                    {
                        if ((string)obj["Date"] == Date)
                        {
                            list.Add(new BoxLog { BoxID = (string)obj["BoxID"], Time = (string)obj["Time"], Date = (string)obj["Date"] });
                        }

                    }
                    list.Reverse();
                    string json_ = JsonConvert.SerializeObject(list);
                    File.WriteAllText(Common.PathBoxC2, json_);
                }
            }
            catch
            {
            }
        }
    }
}
