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
        public string[] LoadEmailConfig(string pFileURL)
        {
            string[] strArrayEmailInfor = new string[4];
            XElement EmailConfigs = XElement.Load(pFileURL);
            var emailcnfgs = from xmlEmailConfig in EmailConfigs.Elements("Email") select xmlEmailConfig;
            foreach (var emailconfig in emailcnfgs)
            {
                //strArrayEmailInfor[0]=emailconfig.Element("POP3").Value;
                //strArrayEmailInfor[1]=emailconfig.Element("PortPOP3").Value;
                strArrayEmailInfor[0]=emailconfig.Element("SMTP").Value;
                strArrayEmailInfor[1]=emailconfig.Element("PortSMTP").Value;
                strArrayEmailInfor[2]=emailconfig.Element("EmailAddress").Value;
                strArrayEmailInfor[3] = emailconfig.Element("EmailName").Value;
                strArrayEmailInfor[4] = emailconfig.Element("Password").Value;
            }
            return strArrayEmailInfor;
        }
    }
}
