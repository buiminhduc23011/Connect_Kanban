using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Net.Http;
using System.Windows.Media;
using Modbus.Device;
using System.Net.Sockets;
using Conv_TF_UI.Class;



namespace Conv_TF_UI
{
    public partial class MainWindow : Window
    {
        //Screen
        Auto_Screen Auto_Screen = new Auto_Screen();
        Manual_Screen Manual_Screen = new Manual_Screen();
        History_Log_Screen History_Log_Screen = new History_Log_Screen();
        Setting_Screen Setting_Screen = new Setting_Screen();
        // Threads
        private CancellationTokenSource workerCancellationTokenSource;
        private CancellationToken workerCancellationToken;

        private Thread Ur_1_Thread;
        private Thread Ur_2_Thread;
        private volatile bool stopThread = false;

        //
        UR Ur1 = new UR();
        private static IModbusMaster Client_1;
        private DataUr data_1 = new DataUr();
        //
        UR Ur2 = new UR();
        private static IModbusMaster Client_2;
        private DataUr data_2 = new DataUr();
        //Variable
        private int flag_error;
        // Init
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            Ur_1_Thread = new Thread(new ThreadStart(Ur_1));
            Ur_2_Thread = new Thread(new ThreadStart(Ur_2));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Common.Init();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.RunWorkerAsync();
            //
            Pannel_Monitor.Children.Add(Auto_Screen);
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Reset.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //

            Ur_1_Thread.Start();
            Ur_2_Thread.Start();
            workerCancellationTokenSource = new CancellationTokenSource();
            workerCancellationToken = workerCancellationTokenSource.Token;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            stopThread = true;
            workerCancellationTokenSource.Cancel();
        }

        private void Ur_1()
        {
            while (!stopThread)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        Ur1.Connect_Ur(Common.IP_Robot_1, Common.Port_Robot_1, tcpClient, out Client_1);
                        data_1 = Ur1.Data(Ur1.isConnect, Client_1, 200, 4);
                        Dispatcher.Invoke(() =>
                        {
                            test1.Content = data_1.Coditon_Ur.ToString() + "/" + data_1.Ur_Control.ToString() + "/" + data_1.Mode_Product.ToString();
                        });
                    }

                }
                catch
                {

                }
            }
        }
        private void Ur_2()
        {
            while (!stopThread)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        Ur2.Connect_Ur(Common.IP_Robot_2, Common.Port_Robot_2, tcpClient, out Client_2);
                        data_2 = Ur2.Data(Ur2.isConnect, Client_2, 200, 4);
                        Dispatcher.Invoke(() =>
                        {
                            test2.Content = data_2.Coditon_Ur.ToString() + "/" + data_2.Ur_Control.ToString() + "/" + data_2.Mode_Product.ToString();
                        });
                    }
                }
                catch
                {

                }
            }
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (!workerCancellationToken.IsCancellationRequested)
            {

                Dispatcher.Invoke(() =>
                {
                    if (IPLC.Reset_Error == 1) bt_Reset.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    else bt_Reset.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    DateTime dateTime = DateTime.Now;
                    string formattedDate = dateTime.ToString("dd/MM/yyyy");
                    lb_DayNow.Content = formattedDate;
                    string formattedtime = dateTime.ToString("HH:mm:ss");
                    lb_Timenow.Content = formattedtime;
                });
                Thread.Sleep(200);
            }
        }
        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(Auto_Screen);
        }
        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(Manual_Screen);
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            IPLC.Reset_Error = 1;
        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            bt_History.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(History_Log_Screen);
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(Setting_Screen);
        }
        private void GPIO_Click(object sender, RoutedEventArgs e)
        {
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Manu.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void bt_Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
