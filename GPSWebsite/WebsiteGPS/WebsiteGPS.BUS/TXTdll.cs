using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.BUS
{
    public class TXTdll
    {
        private string[] lineArgs = new string[50];
        public string[] LineArgs
        {
            set { lineArgs = value; }
            get { return lineArgs; }
        }

        //Load cac file dang text vao array
        public string[] LoadFileToArray(string Path)
        {
            System.IO.StreamReader fs;
            string ss = "";                         //so cap           
            int index = 0;

            char[] equalsign = new char[1];
            equalsign[0] = '=';

            if (System.IO.File.Exists(Path) == true)
            {
                fs = System.IO.File.OpenText(Path);

                while (fs.EndOfStream != true)
                {
                    ss = fs.ReadLine();

                    int i = ss.IndexOfAny(equalsign);   //tim dau '=' trong ss
                    int j = (ss.Length - (i + 1));        //so char con lai sau dau '='

                    lineArgs[index] = ss.Substring(i + 1, j).Trim();
                    index++;
                }

                fs.Close();
            }

            return lineArgs;

        }

        public void SaveFileText(string[] argOptions, string Path)
        {
            System.IO.StreamWriter w;
            w = System.IO.File.CreateText(Path);
            for (int i = 0; i < argOptions.Length; i++)
            {
                w.WriteLine(argOptions[i]);
            }
            w.Close();
        }
        public void SaveFileText(string argOptions, string Path, int _dong)
        {
            System.IO.StreamWriter w;
            w = System.IO.File.CreateText(Path);
            // ghi 1 dong
            w.WriteLine(argOptions, _dong);

            w.Close();
        }
        private Boolean KiemTraFile(String _TenFile)
        {
            if (System.IO.File.Exists(_TenFile) == true) //ton tai
            {
                return true;
            }
            else //khong ton tai
            {
                return false;
            }
        }
    }
}
