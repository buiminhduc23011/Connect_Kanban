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


namespace Conv_TF_UI
{
    public partial class MainWindow : Window
    {
        //Screen
        Auto_Screen Auto_Screen = new Auto_Screen();
        Manual_Screen Manual_Screen = new Manual_Screen();
        History_Log_Screen History_Log_Screen = new History_Log_Screen();
        Setting_Screen Setting_Screen = new Setting_Screen();

        private Thread UpdateScreen_Thread;
        private Thread Ur_1_Thread;
        private Thread Ur_2_Thread;
        private Thread Qr_1_Thread;
        private Thread Qr_2_Thread;
        private Thread Socket_Thread;
        private volatile bool stopThread = false;
        //
        UR Ur1 = new UR();
        private static IModbusMaster Client_1;
        //
        UR Ur2 = new UR();
        private static IModbusMaster Client_2;
        // Serial
        private SerialPort _serialPort1;
        private SerialPort _serialPort2;
        private bool isSerialPort1Initialized = false;
        private bool isSerialPort2Initialized = false;
        //Socket
        public bool ConnectSocket = false;
        private bool IsSendmac = false;
        SocketIO socket;
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
            if (_serialPort1 != null && _serialPort1.IsOpen)
            {
                _serialPort1.Close();
            }
            if (_serialPort2 != null && _serialPort2.IsOpen)
            {
                _serialPort2.Close();
            }
            stopThread = true;
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
                        Data.Ur1 = Ur1.Data(Ur1.isConnect, Client_1, 200, 4);
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
                        Data.Ur2 = Ur2.Data(Ur2.isConnect, Client_2, 200, 4);
                    }
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
                    Thread.Sleep(500);
                }
                catch(Exception ex)
                {
                    isSerialPort1Initialized = false;
                    MessageBox.Show(ex.ToString());
                }
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
                        Thread.Sleep(500);
                    }
                }
                catch (Exception ex)
                {
                    
                    isSerialPort2Initialized = false;
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private async void Socket_()
        {
            while (!stopThread)
            {
                try
                {
                    if (!ConnectSocket)
                    {
                        string host_socket;
                        host_socket = "http://" + Common.IP_Server + ":" + Common.Port_Server;
                        socket = new SocketIO(host_socket);
                        await socket.ConnectAsync();
                        ConnectSocket = true;
                    }
                    if (IsSendmac == false && ConnectSocket == true)
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
                    if(Common.DataQR1!=Common.DataQR1_ && ConnectSocket)
                    {
                        var data = new
                        {
                            mac = Common.GetMacAddress(),
                            ip = Common.IP_Robot_1,
                            box_id = Common.DataQR1,
                        };
                        await socket.EmitAsync("box-running", data);
                        Common.DataQR1_ = Common.DataQR1;
                    }
                    if (Common.DataQR2 != Common.DataQR2_ && ConnectSocket == true)
                    {
                        var data = new
                        {
                            mac = Common.GetMacAddress(),
                            ip = Common.IP_Robot_2,
                            box_id = Common.DataQR2,
                        };
                        await socket.EmitAsync("box-running", data);
                        Common.DataQR2_ = Common.DataQR2;
                    }
                }
                catch { }
            }

        }

        private void UpdateScreen()
        {
            while (!stopThread)
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
