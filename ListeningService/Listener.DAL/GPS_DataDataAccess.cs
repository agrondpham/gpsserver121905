using System;
using System.Collections.Generic;
using System.Text;
using Listener.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Listener.DAL
{
	/// <summary> 
	///Author: nnamthach@gmail.com 
	/// <summary>
    public class GPS_DataDataAccess : Connection
    {
		#region Local Variable
        private string _strSPInsertName = "dbo.[procGPS_Data_add]";
		#endregion Local Variable
		
		#region Method
        /// <summary>
        /// Return 1: Table is exist Identity Field
        /// Return 0: Table is not exist Identity Field
        /// Return -1: Erro
        /// </summary>
        /// <param name="tableName"></param>
        public Int32 Add(GPS_DataInfo objEntr, ref string sErr)
        {
            int ret = -1;
            connect();
            InitSPCommand(_strSPInsertName);
            AddParameter(GPS_DataInfo.Field.IMED_Device.ToString(), objEntr.IMED_Device);
            AddParameter(GPS_DataInfo.Field.Longitude.ToString(), objEntr.Longitude);
            AddParameter(GPS_DataInfo.Field.Latitude.ToString(), objEntr.Latitude);
            AddParameter(GPS_DataInfo.Field.Speed.ToString(), objEntr.Speed);
            AddParameter(GPS_DataInfo.Field.Received_Data.ToString(), objEntr.Received_Data);
            AddParameter(GPS_DataInfo.Field.Status.ToString(), objEntr.Status);
          
            try
            {
                object tmp = executeSPScalar();
                if(tmp != null && tmp != DBNull.Value)
					ret = Convert.ToInt32(tmp);
				else 
					ret=0;
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            if (sErr != "") ErrorLog.SetLog(sErr);
			
            return ret;
        }

  		#endregion Method
     
    }
}
