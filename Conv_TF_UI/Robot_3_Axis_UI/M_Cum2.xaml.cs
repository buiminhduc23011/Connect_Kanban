using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for M_Cum2.xaml
    /// </summary>
    public partial class M_Cum2 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        public M_Cum2()
        {
            InitializeComponent();
            Loaded += Manual_Screen_Loaded;
            Unloaded += Manual_Screen_Unloaded;
        }
        private void Manual_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Manual_Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    Update_Screen();
                });
            }
            catch
            {

            }
        }
        void Update_Screen()
        {

            // Gán giá trị cho D3 và IPLC.D3
            update.bt_Green(D3_0, IPLC.D3_0);
            update.bt_Green(D3_1, IPLC.D3_1);
            update.bt_Green(D3_2, IPLC.D3_2);
            update.bt_Green(D3_3, IPLC.D3_3);
            update.bt_Green(D3_6, IPLC.D3_6);
            update.bt_Green(D3_7, IPLC.D3_7);
            update.bt_Green(D3_8, IPLC.D3_8);
            update.bt_Green(D3_9, IPLC.D3_9);

            // Gán giá trị cho D4 và IPLC.D4
            update.bt_Green(D4_0, IPLC.D4_0);
            update.bt_Green(D4_1, IPLC.D4_1);
            update.bt_Green(D4_2, IPLC.D4_2);
            update.bt_Green(D4_3, IPLC.D4_3);
            update.bt_Green(D4_4, IPLC.D4_4);
            update.bt_Green(D4_5, IPLC.D4_5);
            update.bt_Green(D4_6, IPLC.D4_6);
            update.bt_Green(D4_7, IPLC.D4_7);
            update.bt_Green(D4_8, IPLC.D4_8);
        }
        private void D3_0_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_0) IPLC.D3[0] = false;
            else
            {
                IPLC.D3[0] = true;
                IPLC.D3[1] = false;
            }
        }

        private void D3_1_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_1) IPLC.D3[1] = false;
            else
            {
                IPLC.D3[1] = true;
                IPLC.D3[0] = false;
            }
        }
        private void D3_2_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_2) IPLC.D3[2] = false;
            else
            {
                IPLC.D3[2] = true;
                IPLC.D3[3] = false;
            }
        }
        private void D3_3_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_3) IPLC.D3[3] = false;
            else
            {
                IPLC.D3[3] = true;
                IPLC.D3[2] = false;
            }
        }

        private void D3_6_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_6) IPLC.D3[6] = false;
            else
            {
                IPLC.D3[6] = true;
            }
        }

        private void D3_7_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_7) IPLC.D3[7] = false;
            else
            {
                IPLC.D3[7] = true;
                IPLC.D3[8] = false;
            }
        }

        private void D3_8_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_8) IPLC.D3[8] = false;
            else
            {
                IPLC.D3[8] = true;
                IPLC.D3[7] = false;
            }
        }

        private void D3_9_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D3_9) IPLC.D3[9] = false;
            else
            {
                IPLC.D3[9] = true;
                IPLC.D4[0] = false;
            }
        }
        private void D4_0_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_0) IPLC.D4[0] = false;
            else
            {
                IPLC.D4[0] = true;
                IPLC.D3[9] = false;
            }
        }

        private void D4_1_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_1) IPLC.D4[1] = false;
            else
            {
                IPLC.D4[1] = true;
                IPLC.D4[2] = false;
            }
        }

        private void D4_2_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_2) IPLC.D4[2] = false;
            else
            {
                IPLC.D4[2] = true;
                IPLC.D4[1] = false;
            }
        }

        private void D4_3_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_3) IPLC.D4[3] = false;
            else
            {
                IPLC.D4[3] = true;
                IPLC.D4[4] = false;
            }
        }

        private void D4_4_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_4) IPLC.D4[4] = false;
            else
            {
                IPLC.D4[4] = true;
                IPLC.D4[3] = false;
            }
        }

        private void D4_5_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_5) IPLC.D4[5] = false;
            else
            {
                IPLC.D4[5] = true;
                IPLC.D4[6] = false;
            }
        }

        private void D4_6_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_6) IPLC.D4[6] = false;
            else
            {
                IPLC.D4[6] = true;
                IPLC.D4[5] = false;
            }
        }

        private void D4_7_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_7) IPLC.D4[7] = false;
            else
            {
                IPLC.D4[7] = true;
                IPLC.D4[8] = false;
            }
        }

        private void D4_8_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D4_8) IPLC.D4[8] = false;
            else
            {
                IPLC.D4[8] = true;
                IPLC.D4[7] = false;
            }
        }
    }
}
