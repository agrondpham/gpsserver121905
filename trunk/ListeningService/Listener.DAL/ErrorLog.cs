using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Listener.DAL
{
    public class ErrorLog
    {        
        public static void SetLog(string sErr)
        {
            string result = DateTime.Now.ToString() + ": " + sErr;
            string fileName = "D://LogErro.log";
            StreamWriter streamWr = new StreamWriter(fileName);
            streamWr.NewLine = result;
            streamWr.Close();
        }
    }
}
    