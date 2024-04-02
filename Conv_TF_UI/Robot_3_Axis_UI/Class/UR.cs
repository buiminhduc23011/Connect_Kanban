using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Conv_TF_UI.Class
{
    public class DataUr
    {
        public int Ur_Control { get; set; }
        public int Coditon_Ur { get; set; } 
        public int Mode_Product { get; set; }
    }
    public class UR
    {
        public bool isConnect {  get; set; }
        public void Connect_Ur(string IP, int Port, TcpClient tcpClient, out IModbusMaster Client)
        {
            Client = null;
            int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                try
                {
                    tcpClient.Connect(IP, Port);
                    if (tcpClient.Connected)
                    {
                        Client = ModbusIpMaster.CreateIp(tcpClient);
                        isConnect = true;
                        return; // Successful connection, exit the method
                    }
                }
                catch (SocketException )
                {
                }
                catch (Exception)
                {
                }

                attempts++;
                Thread.Sleep(100); // Wait before retrying
            }
            isConnect = false;
        }
        public DataUr Data(bool IsConnect, IModbusMaster Client, ushort startAddress, ushort numRegisters)
        {
            DataUr dataUr = new DataUr();
            if (IsConnect)
            {
                try
                {

                    ushort[] data = Client.ReadHoldingRegisters(1, startAddress, numRegisters);
                    dataUr.Ur_Control = data[0];
                    dataUr.Coditon_Ur = data[1];
                    dataUr.Mode_Product = data[2];
                }
                catch
                {
                }
            }
            return dataUr;
        }
    }
}
