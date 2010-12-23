using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.BUS
{
    public class ControlBLL
    {
        #region Local Variable
        DAO.ControlsDAL controlDAO = new DAO.ControlsDAL();
        #endregion

        #region Method
        public string[] loadControls(string pControl, string pFileURL) {
            return controlDAO.loadControls(pControl, pFileURL);
        }



        #endregion
    }
}
