using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
namespace WebsiteGPS.BUS
{
    public class ConfigBLL
    {
        #region Local Variable
        DAO.ConfigDataAccess configDAO = new DAO.ConfigDataAccess();
        #endregion

        #region Method
        public ArrayList loadConfigs(string pTheme, string pFileURL)
        {
            return configDAO.loadConfig(pTheme, pFileURL);
        }



        #endregion
    }
}
