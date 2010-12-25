using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Xml.Linq;
namespace WebsiteGPS.BUS
{
    public class LanguageBLL
    {
        #region Local Variable
        DAO.LanguageDataAccess languageDAO = new DAO.LanguageDataAccess();
        #endregion

        #region Method
        public XElement loadLanguageForModule(string pModule, string pFileURL, string pLanguage)
        {
            return languageDAO.loadLanguage(pModule, pFileURL,pLanguage);
        }
        #endregion
    }
}
