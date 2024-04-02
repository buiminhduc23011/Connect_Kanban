using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conv_TF_UI
{
    public static class IPLC
    {
        public static short Ur_Control { get; set; }
        public static short Error { get; set; }
        public static bool Connect_PLC { get; set; }
        // Inout
        public static short Input_0 { get; set; }
        public static short Input_1 { get; set; }
        public static short Input_2 { get; set; }
        public static short Input_3 { get; set; }
        public static short Input_4 { get; set; }
        public static short Input_5 { get; set; }
        public static short Input_6 { get; set; }
        public static short Output_0 { get; set; }
        public static short Output_1 { get; set; }
        public static short Output_2 { get; set; }
        public static short Output_3 { get; set; }
        public static short Output_4 { get; set; }
        public static short Output_5 { get; set; }
        public static short Output_6 { get; set; }

        // Control
        public static short Reset_Error { get; set; }
        //
        public static bool D1_0 { get; set; }
        public static bool D1_1 { get; set; }
        public static bool D1_2 { get; set; }
        public static bool D1_3 { get; set; }
        public static bool D1_4 { get; set; }
        public static bool D1_5 { get; set; }
        public static bool D1_6 { get; set; }
        public static bool D1_7 { get; set; }
        public static bool D1_8 { get; set; }
        public static bool D1_9 { get; set; }

        public static bool D2_0 { get; set; }
        public static bool D2_1 { get; set; }
        public static bool D2_2 { get; set; }
        public static bool D2_3 { get; set; }
        public static bool D2_4 { get; set; }
        public static bool D2_5 { get; set; }
        public static bool D2_6 { get; set; }
        public static bool D2_7 { get; set; }
        public static bool D2_8 { get; set; }
        public static bool D2_9 { get; set; }

        public static bool D3_0 { get; set; }
        public static bool D3_1 { get; set; }
        public static bool D3_2 { get; set; }
        public static bool D3_3 { get; set; }
        public static bool D3_4 { get; set; }
        public static bool D3_5 { get; set; }
        public static bool D3_6 { get; set; }
        public static bool D3_7 { get; set; }
        public static bool D3_8 { get; set; }
        public static bool D3_9 { get; set; }

        public static bool D4_0 { get; set; }
        public static bool D4_1 { get; set; }
        public static bool D4_2 { get; set; }
        public static bool D4_3 { get; set; }
        public static bool D4_4 { get; set; }
        public static bool D4_5 { get; set; }
        public static bool D4_6 { get; set; }
        public static bool D4_7 { get; set; }
        public static bool D4_8 { get; set; }
        public static bool D4_9 { get; set; }

        public static bool D5_0 { get; set; }
        public static bool D5_1 { get; set; }
        public static bool D5_2 { get; set; }
        public static bool D5_3 { get; set; }
        public static bool D5_4 { get; set; }
        public static bool D5_5 { get; set; }
        public static bool D5_6 { get; set; }
        public static bool D5_7 { get; set; }
        public static bool D5_8 { get; set; }
        public static bool D5_9 { get; set; }
        //
        public static bool[] D1 { get; set; } = new bool[16];
        public static bool[] D2 { get; set; } = new bool[16];
        public static bool[] D3 { get; set; } = new bool[16];
        public static bool[] D4 { get; set; } = new bool[16];
        public static bool[] D5 { get; set; } = new bool[16];

        //
        public static short D1_ { get; set; }
        public static short D2_ { get; set; }
        public static short D3_ { get; set; }
        public static short D4_ { get; set; }
        public static short D5_ { get; set; }

        //
        public static short RunHome1 { get; set; }
        public static short RunHome2 { get; set; }
        public static short RunHome1_ { get; set; }
        public static short RunHome2_ { get; set; }
        public static short S_Home1 { get; set; }
        public static short S_Home2 { get; set; }
        public static short S_A_M { get; set; }



    }
}
