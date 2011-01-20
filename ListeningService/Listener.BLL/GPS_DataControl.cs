using System;
using System.Collections.Generic;
using System.Text;
using Listener.DTO;
using Listener.DAL;
using System.Data;

namespace Listener.BLL
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com 
	/// <summary>
    public class GPS_DataControl
    {
		#region Local Variable
        private GPS_DataDataAccess _objDAO;
		#endregion Local Variable
		
		#region Method
        public GPS_DataControl()
        {
            _objDAO = new GPS_DataDataAccess();
        }
		
		
        public Int32 Add(GPS_DataInfo obj, ref string sErr)
        {
            return _objDAO.Add(obj, ref sErr);
        }
		#endregion Method

    }
}
