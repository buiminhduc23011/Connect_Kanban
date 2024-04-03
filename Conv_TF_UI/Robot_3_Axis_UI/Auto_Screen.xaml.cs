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

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Auto_Screen.xaml
    /// </summary>
    public partial class Auto_Screen : UserControl
    {
        Path path = new Path();
        Update_Screen update = new Update_Screen();
        private Thread runThread;
        private volatile bool stopRunThread = false;
        public Auto_Screen()
        {
           
            InitializeComponent();
            Unloaded += Auto_Screen_Unloaded;
            runThread = new Thread(new ThreadStart(MyBackgroundTask));
            string json = File.ReadAllText(path.Setting);
            var data_Setting = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            runThread.Start();
        }
        private void Auto_Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            stopRunThread = true;
        }
        private void MyBackgroundTask()
        {
            while (!stopRunThread)
            {
                try {
                    Dispatcher.Invoke(() =>
                    {
                        Update_Error();
                       
                        txb_Qr1.Text = Common.DataQR1;
                        txb_Qr2.Text = Common.DataQR2;

                    });
                    Thread.Sleep(200);
                }
                catch { }
            }
        }
        void Update_Error()
        {
            System.DateTime dateTime = System.DateTime.Now;
            string formattedDate = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
            if (!IPLC.Connect_PLC)
            {
                lb_Error_Status.Content = "Mất Kết Nối PLC" + "  " + formattedDate;
                lb_Error_Status.Foreground = Brushes.Red;
            }
            else if(IPLC.Error>0)
            {
                string json = File.ReadAllText(path.List_Error);
                string[] errorArray = json.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                lb_Error_Status.Content = errorArray[IPLC.Error - 1].Replace("\r", "").Replace("\n", "") +"  "+ formattedDate;
                lb_Error_Status.Foreground = Brushes.Red;
            }    
            else
            {
                lb_Error_Status.Content = "Hệ Thống Không Lỗi";
                lb_Error_Status.Foreground = Brushes.Green;
            }
        }

    }
}
