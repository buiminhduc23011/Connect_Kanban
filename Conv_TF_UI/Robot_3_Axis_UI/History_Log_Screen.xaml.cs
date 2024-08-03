using Conv_TF_UI.Class;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for History_Log_Screen.xaml
    /// </summary>
    /// 
    public class Items_Error_ReFill
    {
        public string Content_ { get; set; }
        public string Time { get; set; }
    }
    public partial class History_Log_Screen : UserControl
    {
        private DispatcherTimer timer;
        public History_Log_Screen()
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
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
            List<Items_Error> items = new List<Items_Error>();
            List<Items_Error_ReFill> refill = new List<Items_Error_ReFill>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(Common.PathHistory);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)
                    {
                        items.Add(new Items_Error { STT = index, Content_ = (string)obj["Content_"], Time = (string)obj["Time"] });
                        index++;
                    }
                    // Đảo ngược danh sách items
                    items.Reverse();
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].STT = i + 1;
                        if (i < 1000)
                        {
                            refill.Add(new Items_Error_ReFill { Content_ = items[i].Content_, Time = items[i].Time });
                        }
                    }
                    refill.Reverse();
                    string json = JsonConvert.SerializeObject(refill);
                    File.WriteAllText(Common.PathHistory, json);
                    List_Error.ItemsSource = items;
                }

            }
            catch { }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IPLC.List_Error > 0)
            {
                LoadItems();
            }

        }
        private void LoadItems()
        {
            List<Items_Error> items = new List<Items_Error>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(Common.PathHistory);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    items.Clear();
                    foreach (JObject obj in List_Show_array)
                    {
                        items.Add(new Items_Error { STT = index, Content_ = (string)obj["Content_"], Time = (string)obj["Time"] });
                        index++;
                    }
                    // Đảo ngược danh sách items
                    items.Reverse();

                    // Cập nhật lại giá trị thuộc tính STT của từng đối tượng
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].STT = i + 1;
                    }
                    List_Error.ItemsSource = items;
                }
            }
            catch { }
        }
    }
}
