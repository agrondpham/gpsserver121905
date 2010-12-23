using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Xml.Linq;

namespace WebsiteGPS.DAO
{
    public class ControlsDataAccess
    {
        public string[] loadControls(string pControl, string pFileURL)
        {
            string[] strArrayControlInfor=new string[2];
            XElement Controls = XElement.Load(pFileURL);
            var cntrls = from xmlControl in Controls.Elements("Page") where (string)xmlControl.Element("NameUC") == pControl select xmlControl;
            foreach (var control in cntrls)
            {
                strArrayControlInfor[0] = control.Element("URL").Value;//load URL Control
                strArrayControlInfor[1] = control.Element("Title").Value;//Load Title of Control
            }
            return strArrayControlInfor;
        }
    }
}
