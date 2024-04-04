using System;
using System.Collections.Generic;
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
    /// Interaction logic for M_Cum1.xaml
    /// </summary>
    public partial class M_Cum1 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        public M_Cum1()
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
            update.bt_Green(D1_0, IPLC.D1_0);
            update.bt_Green(D1_1, IPLC.D1_1);
            update.bt_Green(D1_2, IPLC.D1_2);
            update.bt_Green(D1_3, IPLC.D1_3);
            update.bt_Green(D1_4, IPLC.D1_4);
            update.bt_Green(D1_5, IPLC.D1_5);
            update.bt_Green(D1_6, IPLC.D1_6);
            update.bt_Green(D1_7, IPLC.D1_7);
            update.bt_Green(D1_8, IPLC.D1_8);
            update.bt_Green(D1_9, IPLC.D1_9);
            // Gán giá trị cho D2 và IPLC.D2
            update.bt_Green(D2_0, IPLC.D2_0);
            update.bt_Green(D2_1, IPLC.D2_1);
            update.bt_Green(D2_2, IPLC.D2_2);
            update.bt_Green(D2_3, IPLC.D2_3);
            update.bt_Green(D2_4, IPLC.D2_4);
            update.bt_Green(D2_5, IPLC.D2_5);
            update.bt_Green(D2_6, IPLC.D2_6);
            update.bt_Green(D2_7, IPLC.D2_7);
            update.bt_Green(D2_8, IPLC.D2_8);
        }
        private void D1_0_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_0) IPLC.D1[0] = false;
            else
            {
                IPLC.D1[0] = true;
                IPLC.D1[1] = false;
            }

        }
        private void D1_1_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_1) IPLC.D1[1] = false;
            else
            {
                IPLC.D1[1] = true;
                IPLC.D1[0] = false;
            }
        }
        private void D1_2_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_2) IPLC.D1[2] = false;
            else
            {
                IPLC.D1[2] = true;
                IPLC.D1[3] = false;
            }

        }
        private void D1_3_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_3) IPLC.D1[3] = false;
            else
            {
                IPLC.D1[3] = true;
                IPLC.D1[2] = false;
            }
        }

        private void D1_4_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_4) IPLC.D1[4] = false;
            else
            {
                IPLC.D1[4] = true;
                IPLC.D1[5] = false;
            }
        }

        private void D1_5_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_5) IPLC.D1[5] = false;
            else
            {
                IPLC.D1[5] = true;
                IPLC.D1[4] = false;
            }
        }

        private void D1_6_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_6) IPLC.D1[6] = false;
            else
            {
                IPLC.D1[6] = true;
            }
        }

        private void D1_7_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_7) IPLC.D1[7] = false;
            else
            {
                IPLC.D1[7] = true;
                IPLC.D1[8] = false;
            }
        }

        private void D1_8_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_8) IPLC.D1[8] = false;
            else
            {
                IPLC.D1[8] = true;
                IPLC.D1[7] = false;
            }
        }

        private void D1_9_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D1_9) IPLC.D1[9] = false;
            else
            {
                IPLC.D1[9] = true;
                IPLC.D2[0] = false;
            }
        }
        private void D2_0_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_0) IPLC.D2[0] = false;
            else
            {
                IPLC.D2[0] = true;
                IPLC.D1[9] = false;
            }
        }

        private void D2_1_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_1) IPLC.D2[1] = false;
            else
            {
                IPLC.D2[1] = true;
                IPLC.D2[2] = false;
            }
        }

        private void D2_2_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_2) IPLC.D2[2] = false;
            else
            {
                IPLC.D2[2] = true;
                IPLC.D2[1] = false;
            }
        }

        private void D2_3_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_3) IPLC.D2[3] = false;
            else
            {
                IPLC.D2[3] = true;
                IPLC.D2[4] = false;
            }
        }

        private void D2_4_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_4) IPLC.D2[4] = false;
            else
            {
                IPLC.D2[4] = true;
                IPLC.D2[3] = false;
            }
        }

        private void D2_5_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_5) IPLC.D2[5] = false;
            else
            {
                IPLC.D2[5] = true;
                IPLC.D2[6] = false;
            }
        }

        private void D2_6_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_6) IPLC.D2[6] = false;
            else
            {
                IPLC.D2[6] = true;
                IPLC.D2[5] = false;
            }
        }

        private void D2_7_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_7) IPLC.D2[7] = false;
            else
            {
                IPLC.D2[7] = true;
                IPLC.D2[8] = false;
            }
        }

        private void D2_8_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D2_8) IPLC.D2[8] = false;
            else
            {
                IPLC.D2[8] = true;
                IPLC.D2[7] = false;
            }
        }
    }
}
