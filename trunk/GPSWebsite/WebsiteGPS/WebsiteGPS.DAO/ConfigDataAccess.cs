using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.Collections;
namespace WebsiteGPS.DAO
{
    public class ConfigDataAccess
    {
        public ArrayList loadConfig(string pTheme, string pFileURL)
        {
            ArrayList strArrayThemeInfor = new ArrayList();
            XElement Configs = XElement.Load(pFileURL);
            var cnfgs = from xmlConfig in Configs.Elements("Config") where (string)xmlConfig.Element("ThemeName") == pTheme select xmlConfig;
            foreach (var config in cnfgs)
            {
                strArrayThemeInfor.Add(config.Element("ThemeName").Value);//load all config
                strArrayThemeInfor.Add(config.Element("ThemeURL").Value);
                strArrayThemeInfor.Add(config.Element("Language").Value);
            }
            return strArrayThemeInfor;
        }
    }
}
