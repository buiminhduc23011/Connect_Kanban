using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Text.Json;
using System.IO;
using System.Windows.Media;
using System.Configuration;

namespace Conv_TF_UI
{
    /// <summary>
    /// Interaction logic for Manual_Screen.xaml
    /// </summary>
    public partial class Manual_Screen : UserControl
    {
        Update_Screen update = new Update_Screen();
        Path path = new Path();
        private DispatcherTimer timer;

        public Manual_Screen()
        {
            InitializeComponent();
            Loaded += Manual_Screen_Loaded;
            Unloaded += Manual_Screen_Unloaded;  
        }
        private void Manual_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(path.Setting);
            var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
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
        private void D1_0_Click(object sender, RoutedEventArgs e)
        {
            //if(IPLC.D1_0) IPLC.D1[0] = false;
            //else
            //{
            //    IPLC.D1[0] = true;
            //    IPLC.D1[1] = false;
            //}
            IPLC.D1[0] = true;
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
