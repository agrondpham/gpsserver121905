using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Listener.DAL
{
    public class ErrorLog
    {   
        public static void SetLog(string sErr)
        {
            
            //string path = Server.MapPath;
            string result = DateTime.Now.ToString() + ": " + sErr;
            string fileName = HttpContext.Current.Server.MapPath("~//loi.txt");// "LogError.txt";
            TextWriter streamWr = new StreamWriter(fileName);
            streamWr.Write(result);
            streamWr.Close();
        }
    }
}
    