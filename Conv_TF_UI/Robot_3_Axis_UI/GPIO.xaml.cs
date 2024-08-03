using Conv_TF_UI.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for GPIO.xaml
    /// </summary>
    public partial class GPIO : UserControl
    {
        private DispatcherTimer timer;
        Update_Screen ud = new Update_Screen();
        public GPIO()
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

                    });
                    Thread.Sleep(200);
                }
                catch { }

            }
            void Update_Error()
            {
                ud.IO(X0, IPLC.X[0]);
                ud.IO(X1, IPLC.X[1]);
                ud.IO(X2, IPLC.X[2]);
                ud.IO(X3, IPLC.X[3]);
                ud.IO(X4, IPLC.X[4]);
                ud.IO(X5, IPLC.X[5]);
                ud.IO(X6, IPLC.X[6]);
                ud.IO(X7, IPLC.X[7]);
                ud.IO(X10, IPLC.X[8]);
                ud.IO(X11, IPLC.X[9]);
                ud.IO(X12, IPLC.X[10]);
                ud.IO(X13, IPLC.X[11]);
                ud.IO(X14, IPLC.X[12]);
                ud.IO(X15, IPLC.X[13]);
                ud.IO(X16, IPLC.X[14]);
                ud.IO(X17, IPLC.X[15]);
                ud.IO(X20, IPLC.X[16]);
                ud.IO(X21, IPLC.X[17]);
                ud.IO(X22, IPLC.X[18]);
                ud.IO(X23, IPLC.X[19]);
                ud.IO(X24, IPLC.X[20]);
                ud.IO(X25, IPLC.X[21]);
                ud.IO(X26, IPLC.X[22]);
                ud.IO(X27, IPLC.X[23]);
                ud.IO(X30, IPLC.X[24]);
                ud.IO(X31, IPLC.X[25]);
                ud.IO(X32, IPLC.X[26]);
                ud.IO(X33, IPLC.X[27]);
                ud.IO(X34, IPLC.X[28]);
                ud.IO(X35, IPLC.X[29]);
                ud.IO(X36, IPLC.X[30]);
                ud.IO(X37, IPLC.X[31]);
                ud.IO(X40, IPLC.X[32]);
                ud.IO(X41, IPLC.X[33]);
                ud.IO(X42, IPLC.X[34]);
                ud.IO(X43, IPLC.X[35]);
                ud.IO(X44, IPLC.X[36]);
                ud.IO(X45, IPLC.X[37]);
                ud.IO(X46, IPLC.X[38]);
                ud.IO(X47, IPLC.X[39]);
                ud.IO(X50, IPLC.X[40]);
                ud.IO(X51, IPLC.X[41]);
                ud.IO(X52, IPLC.X[42]);
                ud.IO(X53, IPLC.X[43]);
                ud.IO(X54, IPLC.X[44]);
                ud.IO(X55, IPLC.X[45]);
                ud.IO(X56, IPLC.X[46]);
                ud.IO(X57, IPLC.X[47]);
                ud.IO(X60, IPLC.X[48]);
                ud.IO(X61, IPLC.X[49]);
                ud.IO(X62, IPLC.X[50]);
                ud.IO(X63, IPLC.X[51]);
                ud.IO(X64, IPLC.X[52]);
                ud.IO(X65, IPLC.X[53]);
                ud.IO(X66, IPLC.X[54]);
                ud.IO(X67, IPLC.X[55]);
                ud.IO(X70, IPLC.X[56]);
                ud.IO(X71, IPLC.X[57]);
                ud.IO(X72, IPLC.X[58]);
                ud.IO(X73, IPLC.X[59]);
                ud.IO(X74, IPLC.X[60]);
                ud.IO(X75, IPLC.X[61]);
                ud.IO(X76, IPLC.X[62]);

                //
                ud.IO(Y0, IPLC.Y[0]);
                ud.IO(Y1, IPLC.Y[1]);
                ud.IO(Y2, IPLC.Y[2]);
                ud.IO(Y3, IPLC.Y[3]);
                ud.IO(Y4, IPLC.Y[4]);
                ud.IO(Y5, IPLC.Y[5]);
                ud.IO(Y6, IPLC.Y[6]);
                ud.IO(Y7, IPLC.Y[7]);
                ud.IO(Y10, IPLC.Y[8]);
                ud.IO(Y11, IPLC.Y[9]);
                ud.IO(Y12, IPLC.Y[10]);
                ud.IO(Y13, IPLC.Y[11]);
                ud.IO(Y14, IPLC.Y[12]);
                ud.IO(Y15, IPLC.Y[13]);
                ud.IO(Y16, IPLC.Y[14]);
                ud.IO(Y17, IPLC.Y[15]);
                ud.IO(Y20, IPLC.Y[16]);
                ud.IO(Y21, IPLC.Y[17]);
                ud.IO(Y22, IPLC.Y[18]);
                ud.IO(Y23, IPLC.Y[19]);
                ud.IO(Y24, IPLC.Y[20]);
                ud.IO(Y25, IPLC.Y[21]);
                ud.IO(Y26, IPLC.Y[22]);
                ud.IO(Y27, IPLC.Y[23]);
                ud.IO(Y30, IPLC.Y[24]);
                ud.IO(Y31, IPLC.Y[25]);
                ud.IO(Y32, IPLC.Y[26]);
                ud.IO(Y33, IPLC.Y[27]);
                ud.IO(Y34, IPLC.Y[28]);
                ud.IO(Y35, IPLC.Y[29]);
                ud.IO(Y36, IPLC.Y[30]);
                ud.IO(Y37, IPLC.Y[31]);
                ud.IO(Y40, IPLC.Y[32]);
                ud.IO(Y41, IPLC.Y[33]);
                ud.IO(Y42, IPLC.Y[34]);
                ud.IO(Y43, IPLC.Y[35]);
                ud.IO(Y44, IPLC.Y[36]);
                ud.IO(Y45, IPLC.Y[37]);
                ud.IO(Y46, IPLC.Y[38]);
                ud.IO(Y47, IPLC.Y[39]);
                ud.IO(Y50, IPLC.Y[40]);
                ud.IO(Y51, IPLC.Y[41]);
                ud.IO(Y52, IPLC.Y[42]);
                ud.IO(Y53, IPLC.Y[43]);
                ud.IO(Y54, IPLC.Y[44]);
                ud.IO(Y55, IPLC.Y[45]);
                ud.IO(Y56, IPLC.Y[46]);
                ud.IO(Y57, IPLC.Y[47]);
                ud.IO(Y60, IPLC.Y[48]);
                ud.IO(Y61, IPLC.Y[49]);
                ud.IO(Y62, IPLC.Y[50]);
                ud.IO(Y63, IPLC.Y[51]);
                ud.IO(Y64, IPLC.Y[52]);
                ud.IO(Y65, IPLC.Y[53]);
                ud.IO(Y66, IPLC.Y[54]);
                ud.IO(Y67, IPLC.Y[55]);
                ud.IO(Y70, IPLC.Y[56]);
                ud.IO(Y71, IPLC.Y[57]);
                ud.IO(Y72, IPLC.Y[58]);
                ud.IO(Y73, IPLC.Y[59]);
                ud.IO(Y74, IPLC.Y[60]);
                ud.IO(Y75, IPLC.Y[61]);
                ud.IO(Y76, IPLC.Y[62]);
            }
        }
    }
}

