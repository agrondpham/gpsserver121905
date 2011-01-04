using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
namespace WebsiteGPS.DAO
{
    public class ErrorsDataAccess
    {
        public string loadError(string pErrorCode, string pFileURL, string pLanguage)
        {
            string strError = "";
            XElement Errors = XElement.Load(pFileURL);
            var ErrorInfos = from xmlError in Errors.Elements("Error") where (string)xmlError.Element("Code") == pErrorCode select xmlError;
            foreach (var errorInfor in ErrorInfos)
            {
                if (pLanguage.ToLower() == "en-us")
                {
                    strError = errorInfor.Element("en-US").Value;//Ngon ngu tieng anh
                }
                else
                {
                    strError = errorInfor.Element("vi-VN").Value;//ngon ngu tieng viet
                }
            }
            return strError;
        }
    }
}
