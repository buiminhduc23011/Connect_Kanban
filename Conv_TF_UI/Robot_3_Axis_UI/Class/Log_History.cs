using System;
using System.IO;

namespace Conv_TF_UI.Class
{
    public class Log_History
    {
        public void Log_His(int ErID, string path_his, string ListErr, int flag_error)
        {
            if (ErID > 0)
            {
                flag_error++;
                if (flag_error == 1)
                {
                    DateTime dateTime = DateTime.Now;
                    string formattedDate_ = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    string json_ = File.ReadAllText(ListErr);
                    string[] errorArray = json_.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    string json = File.ReadAllText(path_his);
                    json = json.Remove(json.Length - 1);
                    json = json + "," + "{\"Content_\": " + "\"" + errorArray[ErID - 1].Replace("\r", "").Replace("\n", "") + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                    File.WriteAllText(path_his, json);
                }
            }
            else
            {
                flag_error = 0;
            }
        }
    }
}
