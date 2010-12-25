using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
namespace WebsiteGPS.BUS
{
    public class ErrorsBLL
    {
        #region local Variable
        DAO.ErrorsDataAccess errorDAO = new DAO.ErrorsDataAccess();
        #endregion
        #region method
        public string loadError(string pErrorCode, string pFileURL,string pLanguage)
        {
            return errorDAO.loadError(pErrorCode, pFileURL, pLanguage);
        }
        #endregion
    }
}
