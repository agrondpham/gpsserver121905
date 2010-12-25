using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Xml.Linq;
namespace WebsiteGPS.DAO
{
    public class LanguageDataAccess
    {
        public XElement loadLanguage(string pModule, string pFileURL,string pLanguage)
        {
            //ArrayList strArrayComponents= new ArrayList();
            XElement Components=null;
            XElement Modules = XElement.Load(pFileURL);
            var mdls = from xmlModule in Modules.Elements("Module") where (string)xmlModule.Element("PageName") == pModule select xmlModule;
            foreach (var module in mdls)
            {
                string xml=@"<?xml version=""1.0""?>"+module.ToString();
 
                Components=XElement.Parse(xml);//load all config
            }
            return Components;
        }
    }
}
