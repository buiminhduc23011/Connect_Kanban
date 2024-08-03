using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Modbus.Device;
using System.Net.Sockets;
using Conv_TF_UI.Class;
using System.IO.Ports;
using SocketIOClient;
using System.Linq.Expressions;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Media3D;


namespace Conv_TF_UI
{
    public partial class MainWindow : Window
    {
        //Screen
        Auto_Screen Auto_Screen = new Auto_Screen();
        Manual_Screen Manual_Screen = new Manual_Screen();
        History_Log_Screen History_Log_Screen = new History_Log_Screen();
        Setting_Screen Setting_Screen = new Setting_Screen();
        GPIO Gpio_Screen = new GPIO();
        Update_Screen Ud = new Update_Screen();

        private Thread UpdateScreen_Thread;
        private Thread Ur_1_Thread;
        private Thread Ur_2_Thread;
        private Thread Qr_1_Thread;
        private Thread Qr_2_Thread;
        private Thread Socket_Thread;

        private volatile bool stopThread = false;
        //
        UR Ur1 = new UR();
        public static bool Ur1_Connected;
        private static IModbusMaster Client_1;
        private int Mode_Run_1_Temp;
        private int Ur1_Control_Temp;
        //
        UR Ur2 = new UR();
        public static bool Ur2_Connected;
        private static IModbusMaster Client_2;
        // Serial
        private SerialPort _serialPort1;
        private SerialPort _serialPort2;
        public static bool isSerialPort1Initialized = false;
        public static bool isSerialPort2Initialized = false;
        //Socket
        public static bool ConnectSocket = false;
        private bool IsSendmac = false;
        SocketIO socket;
        //
        PLC plc = new PLC();
        //
        Log log = new Log();
        private int Flag_Er = 0;
        private bool flag_Send_QR1 = false;
        private bool flag_Send_QR2 = false;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            Ur_1_Thread = new Thread(new ThreadStart(Ur_1));
            Ur_2_Thread = new Thread(new ThreadStart(Ur_2));
            Qr_1_Thread = new Thread(new ThreadStart(Qr_1));
            Qr_2_Thread = new Thread(new ThreadStart(Qr_2));
            Socket_Thread = new Thread(new ThreadStart(Socket_));
            UpdateScreen_Thread = new Thread(new ThreadStart(UpdateScreen));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Common.Init();
            plc.Start();
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
            Qr_1_Thread.Start();
            Qr_2_Thread.Start();
            Socket_Thread.Start();
            UpdateScreen_Thread.Start();
            //

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            plc.Stop();
            Pannel_Monitor.Children.Clear();
            if (_serialPort1 != null && _serialPort1.IsOpen)
            {
                _serialPort1.Close();
            }
            if (_serialPort2 != null && _serialPort2.IsOpen)
            {
                _serialPort2.Close();
            }
            stopThread = true;
            //
            List<Thread> threadsToClose = new List<Thread>
            {
                Ur_1_Thread,
                Ur_2_Thread,
                Qr_1_Thread,
                Qr_2_Thread,
                Socket_Thread,
                UpdateScreen_Thread
            };
            foreach (Thread thread in threadsToClose)
            {
                if (thread != null)
                {
                    thread.Abort();
                }
            }

        }

        private void Ur_1()
        {
            while (!stopThread)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        Ur1_Connected = Ur1.isConnect;
                        Ur1.Connect_Ur(Common.IP_Robot_1, Common.Port_Robot_1, tcpClient, out Client_1);
                        Data.Ur1 = Ur1.Data(Ur1.isConnect, Client_1, 200, 4, ushort.Parse(IPLC.Codition_RB1.ToString()));
                        if (Data.Ur1.Mode_Product != Mode_Run_1_Temp && PLC.Isconnect == true && Ur1.isConnect == true)
                        {
                            if (Data.Ur1.Mode_Product == 2)
                            {
                                var data = new Dictionary<string, object>
                                    {
                                        { "Mode_Run_1", 1 }
                                    };
                                string jsonData = JsonConvert.SerializeObject(data);
                                plc.Write(jsonData);
                            }
                            else
                            {
                                var data = new Dictionary<string, object>
                                    {
                                        { "Mode_Run_1", 0 }
                                    };
                                string jsonData = JsonConvert.SerializeObject(data);
                                plc.Write(jsonData);
                            }
                            Mode_Run_1_Temp = Data.Ur1.Mode_Product;
                        }
                        else
                        {
                            Mode_Run_1_Temp = 2011;
                        }
                        if (Data.Ur1.Ur_Control != Ur1_Control_Temp && PLC.Isconnect == true && Ur1.isConnect == true)
                        {
                            var data = new Dictionary<string, object>
                                    {
                                        { "Ur_Control_1", Data.Ur1.Ur_Control }
                                    };
                            string jsonData = JsonConvert.SerializeObject(data);
                            plc.Write(jsonData);
                            Ur1_Control_Temp = Data.Ur1.Ur_Control;
                        }
                        else
                        {
                            Ur1_Control_Temp = 2011;
                        }
                        if (IPLC.Ur_Control_1 != 0) Client_1.WriteSingleRegister(1, 200, 0);
                    }
                    Thread.Sleep(100);
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
                        Ur2_Connected = Ur2.isConnect;
                        Ur2.Connect_Ur(Common.IP_Robot_2, Common.Port_Robot_2, tcpClient, out Client_2);
                        Data.Ur2 = Ur2.Data(Ur2.isConnect, Client_2, 200, 4, ushort.Parse(IPLC.Codition_RB1.ToString()));
                    }
                    Thread.Sleep(100);
                }
                catch
                {

                }
            }
        }
        private void Qr_1()
        {
            while (!stopThread)
            {
                try
                {
                    if (!isSerialPort1Initialized)
                    {
                        if (_serialPort1 != null && _serialPort1.IsOpen)
                        {
                            _serialPort1.Close();
                        }
                        try
                        {
                            _serialPort1 = new SerialPort(Common.Port_QR_1, 9600, Parity.None, 8, StopBits.One);
                            _serialPort1.Open();
                            isSerialPort1Initialized = true;
                        }
                        catch
                        {
                            isSerialPort1Initialized = false;
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        if (_serialPort1.BytesToRead > 0)
                        {
                            Common.DataQR1 = _serialPort1.ReadExisting().Replace("\r", "").Replace("\n", "");
                        }
                    }
                }
                catch
                {
                    isSerialPort1Initialized = false;
                }
                Thread.Sleep(1);
            }
        }
        private void Qr_2()
        {
            while (!stopThread)
            {
                try
                {
                    if (!isSerialPort2Initialized)
                    {
                        if (_serialPort2 != null && _serialPort2.IsOpen)
                        {
                            _serialPort2.Close();
                        }
                        try
                        {
                            _serialPort2 = new SerialPort(Common.Port_QR_2, 9600, Parity.None, 8, StopBits.One);
                            _serialPort2.Open();
                            isSerialPort2Initialized = true;
                        }
                        catch
                        {
                            isSerialPort2Initialized = false;
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        if (_serialPort2.BytesToRead > 0)
                        {
                            Common.DataQR2 = _serialPort2.ReadExisting().Replace("\r", "").Replace("\n", "");
                        }
                    }
                }
                catch
                {
                    isSerialPort2Initialized = false;
                }
                Thread.Sleep(1);
            }
        }
        private async void Socket_()
        {
            while (!stopThread)
            {
                try
                {
                    if (IPLC.X[21] == false) flag_Send_QR1 = false;
                    if (IPLC.X[39] == false) flag_Send_QR2 = false;
                    if (!ConnectSocket)
                    {
                        string host_socket;
                        host_socket = "http://" + Common.IP_Server + ":" + Common.Port_Server;
                        socket = new SocketIO(host_socket);
                        await socket.ConnectAsync();
                        ConnectSocket = true;
                    }
                    else
                    {

                        if (IsSendmac == false)
                        {
                            var mac = new
                            {
                                mac = Common.GetMacAddress(),
                            };
                            await socket.EmitAsync("connect-machine", mac);
                            ConnectSocket = true;
                            IsSendmac = true;
                        }
                        socket.OnConnected += (eventSender, eventArgs) =>
                        {
                            ConnectSocket = true;
                        };
                        socket.OnDisconnected += (eventSender, eventArgs) =>
                        {
                            ConnectSocket = false;
                            IsSendmac = false;
                        };
                        if (Common.DataQR1 != Common.DataQR1_ && Common.DataQR1.Length >= 6 && Common.DataQR1.Length < 10 && flag_Send_QR1 == false && IPLC.X[21] == true)
                        {
                            var data = new
                            {
                                mac = Common.GetMacAddress(),
                                ip = Common.ID_Robot_1,
                                box_id = Common.DataQR1,
                            };
                            await socket.EmitAsync("box-running", data);
                            Common.DataQR1_ = Common.DataQR1;
                            flag_Send_QR1 = true;
                        }
                        if (Common.DataQR2 != Common.DataQR2_ && Common.DataQR2.Length >= 5 && Common.DataQR2.Length < 10 && flag_Send_QR2 == false && IPLC.X[39] == true)
                        {
                            var data = new
                            {
                                mac = Common.GetMacAddress(),
                                ip = Common.ID_Robot_2,
                                box_id = Common.DataQR2,
                            };
                            await socket.EmitAsync("box-running", data);
                            Common.DataQR2_ = Common.DataQR2;
                            flag_Send_QR2 = true;
                        }
                    }
                }
                catch
                {
                }
                Thread.Sleep(200);
            }

        }

        private void UpdateScreen()
        {
            while (!stopThread)
            {
                if (IPLC.List_Error > 0)
                {
                    Flag_Er++;
                    if (Flag_Er == 1)
                    {
                        DateTime dateTime = DateTime.Now;
                        string formattedDate_ = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                        string json_ = File.ReadAllText(Common.PathList_Error);
                        string[] errorArray = json_.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        string json = File.ReadAllText(Common.PathHistory);
                        json = json.Remove(json.Length - 1);
                        json = json + "," + "{\"Content_\": " + "\"" + errorArray[IPLC.List_Error - 1].Replace("\r", "").Replace("\n", "") + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                        File.WriteAllText(Common.PathHistory, json);
                    }
                }
                else
                {
                    Flag_Er = 0;
                }
                
                Dispatcher.Invoke(() =>
                {
                    Ud.bt_Blue(bt_Reset, IPLC.Reset_Error, false);
                    DateTime dateTime = DateTime.Now;
                    string formattedDate = dateTime.ToString("dd/MM/yyyy");
                    string formattedtime = dateTime.ToString("HH:mm:ss");
                    lb_DayNow.Content = formattedDate + " " + formattedtime;
                    if (IPLC.S_AM == true) lb_S_AM.Content = "Tự Động";
                    else lb_S_AM.Content = "Bằng Tay";
                });
                
                Thread.Sleep(500);

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
            var data = new Dictionary<string, object>
                        {
                            { "Reset_Error", true }
                        };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
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
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(Gpio_Screen);
        }

        private void bt_Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
