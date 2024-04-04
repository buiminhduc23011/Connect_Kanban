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
    /// Interaction logic for M_Cum3.xaml
    /// </summary>
    public partial class M_Cum3 : UserControl
    {
        Update_Screen update = new Update_Screen();
        private DispatcherTimer timer;
        public M_Cum3()
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
            // Gán giá trị cho D5 và IPLC.D5
            update.bt_Green(D5_0, IPLC.D5_0);
            update.bt_Green(D5_1, IPLC.D5_1);
            update.bt_Green(D5_2, IPLC.D5_2);
            update.bt_Green(D5_3, IPLC.D5_3);
            update.bt_Green(D5_4, IPLC.D5_4);
            update.bt_Green(D5_5, IPLC.D5_5);
            update.bt_Green(D5_6, IPLC.D5_6);
            update.bt_Green(D5_7, IPLC.D5_7);
            update.bt_Green(D5_8, IPLC.D5_8);
        }

        private void D5_0_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_0) IPLC.D5[0] = false;
            else
            {
                IPLC.D5[0] = true;
            }
        }

        private void D5_1_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_1) IPLC.D5[1] = false;
            else
            {
                IPLC.D5[1] = true;
                IPLC.D5[2] = false;
            }
        }

        private void D5_2_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_2) IPLC.D5[2] = false;
            else
            {
                IPLC.D5[2] = true;
                IPLC.D5[1] = false;
            }
        }

        private void D5_3_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_3) IPLC.D5[3] = false;
            else
            {
                IPLC.D5[3] = true;
            }
        }

        private void D5_4_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_4) IPLC.D5[4] = false;
            else
            {
                IPLC.D5[4] = true;
            }
        }

        private void D5_5_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_5) IPLC.D5[5] = false;
            else
            {
                IPLC.D5[5] = true;
                IPLC.D5[6] = false;
            }
        }

        private void D5_6_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_6) IPLC.D5[6] = false;
            else
            {
                IPLC.D5[6] = true;
                IPLC.D5[5] = false;
            }
        }

        private void D5_7_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_7) IPLC.D5[7] = false;
            else
            {
                IPLC.D5[7] = true;
                IPLC.D5[8] = false;
            }
        }

        private void D5_8_Click(object sender, RoutedEventArgs e)
        {
            if (IPLC.D5_8) IPLC.D5[8] = false;
            else
            {
                IPLC.D5[8] = true;
                IPLC.D5[7] = false;
            }
        }
    }
}
