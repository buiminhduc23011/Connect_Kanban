using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Conv_TF_UI
{
    public class Update_Screen
    {
        public void bt_Green(Button button, bool Status)
        {
            if (Status)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            }
            else
            {
                button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        public void bt_Blue_0(Button button, int Status)
        {
            if (Status == 0)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            }
            else
            {
                button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        public void bt_Blue_1(Button button, int Status)
        {
            if (Status == 1)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            }
            else
            {
                button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        public void bt_Green_2(Button button, int Status)
        {
            if (Status == 2)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            }
            else
            {
                button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        public void Inout(Button button, bool Status)
        {
            if (Status)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(0,255,0));
            }
            else
            {
                button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        public void label(Label label, int Status)
        {
            if (Status == 1)
            {
                label.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else
            {
                label.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
            }
        }

    }
}
