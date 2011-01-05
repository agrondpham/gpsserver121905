using System;
using System.Collections.Generic;
using System.Text;
using WebsiteGPS.DTO;
using System.Data;
using System.Data.SqlClient;


namespace WebsiteGPS.DAO
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com 
	/// <summary>
    public class GPS_DataDataAccess : WebsiteGPS.DAO.Connection
    {
		#region Local Variable
        private string _strSPInsertName = "dbo.[procGPS_Data_add]";
        private string _strSPUpdateName = "dbo.[procGPS_Data_update]";
        private string _strSPDeleteName = "dbo.[procGPS_Data_delete]";
        private string _strSPGetName = "dbo.[procGPS_Data_get]";
        private string _strSPGetAllName = "dbo.[procGPS_Data_getall]";
		private string _strSPGetPages = "dbo.[procGPS_Data_getpaged]";
		private string _strSPIsExist = "dbo.[procGPS_Data_isexist]";
        private string _strTableName = "[GPS_Data]";
		private string _strSPGetTransferOutName = "dbo.[procGPS_Data_gettransferout]";
		#endregion Local Variable
		
		#region Method
        public GPS_DataInfo Get(
        Int32 ID_Data,
		ref string sErr)
        {
			GPS_DataInfo objEntr = new GPS_DataInfo();
			connect();
			InitSPCommand(_strSPGetName);              
            AddParameter(GPS_DataInfo.Field.ID_Data.ToString(), ID_Data);
            
            DataTable list = new DataTable();
            try
            {
                list = executeSelectSP(command);
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();  
            
            if (list.Rows.Count > 0)
                objEntr = (GPS_DataInfo)GetDataFromDataRow(list, 0);
            //if (dr != null) list = CBO.FillCollection(dr, ref list);
            if (sErr != "") ErrorLog.SetLog(sErr);
            return objEntr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            GPS_DataInfo result = new GPS_DataInfo();
            result.ID_Data = (dt.Rows[i][GPS_DataInfo.Field.ID_Data.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][GPS_DataInfo.Field.ID_Data.ToString()]));
            result.IMED_Device = (dt.Rows[i][GPS_DataInfo.Field.IMED_Device.ToString()] == DBNull.Value ? "" : dt.Rows[i][GPS_DataInfo.Field.IMED_Device.ToString()].ToString());
            result.Longitude = (dt.Rows[i][GPS_DataInfo.Field.Longitude.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][GPS_DataInfo.Field.Longitude.ToString()]));
            result.Latitude = (dt.Rows[i][GPS_DataInfo.Field.Latitude.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][GPS_DataInfo.Field.Latitude.ToString()]));
            result.Speed = (dt.Rows[i][GPS_DataInfo.Field.Speed.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][GPS_DataInfo.Field.Speed.ToString()]));
            result.Received_Data = (dt.Rows[i][GPS_DataInfo.Field.Received_Data.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][GPS_DataInfo.Field.Received_Data.ToString()]));
            result.Status = (dt.Rows[i][GPS_DataInfo.Field.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][GPS_DataInfo.Field.Status.ToString()]));
           
            return result;
        }

        public DataTable GetAll(
        ref string sErr)
        {
            connect();
            InitSPCommand(_strSPGetAllName);
            DataTable list = new DataTable();
            try
            {
                list = executeSelectSP();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();


            if (sErr != "") ErrorLog.SetLog(sErr);
            return list;
        }
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
                //command.ExecuteNonQuery();
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

        public string Update(GPS_DataInfo objEntr)
        {
            connect();
            InitSPCommand(_strSPUpdateName);
            AddParameter(GPS_DataInfo.Field.ID_Data.ToString(), objEntr.ID_Data);
            AddParameter(GPS_DataInfo.Field.IMED_Device.ToString(), objEntr.IMED_Device);
            AddParameter(GPS_DataInfo.Field.Longitude.ToString(), objEntr.Longitude);
            AddParameter(GPS_DataInfo.Field.Latitude.ToString(), objEntr.Latitude);
            AddParameter(GPS_DataInfo.Field.Speed.ToString(), objEntr.Speed);
            AddParameter(GPS_DataInfo.Field.Received_Data.ToString(), objEntr.Received_Data);
            AddParameter(GPS_DataInfo.Field.Status.ToString(), objEntr.Status);
               
            string sErr = "";
            try
            {
                excuteSPNonQuery();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            if (sErr != "") ErrorLog.SetLog(sErr);
            return sErr;
        }

        public string Delete(
        Int32 ID_Data
		)
        {
            connect();
            InitSPCommand(_strSPDeleteName);
            AddParameter(GPS_DataInfo.Field.ID_Data.ToString(), ID_Data);
              
            string sErr = "";
            try
            {
                excuteSPNonQuery();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            if (sErr != "") ErrorLog.SetLog(sErr);
            return sErr;
        }   
		
		public DataTableCollection Get_Page(GPS_DataInfo obj, string orderBy, int pageIndex, int pageSize, ref String sErr)
        {
			string whereClause = CreateWhereClause(obj);
            DataTableCollection dtList = null;
            connect();
            InitSPCommand(_strSPGetPages); 
          
            AddParameter("WhereClause", whereClause);
            AddParameter("OrderBy", orderBy);
            AddParameter("PageIndex", pageIndex);
            AddParameter("PageSize", pageSize);
            
            try
            {
                dtList = executeCollectSelectSP();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            if (sErr != "") ErrorLog.SetLog(sErr);
            return dtList;
        }
        
        public Boolean IsExist(
        Int32 ID_Data
		)
        {
            connect();
            InitSPCommand(_strSPIsExist);
            AddParameter(GPS_DataInfo.Field.ID_Data.ToString(), ID_Data);
              
            string sErr = "";
            DataTable list = new DataTable();
            try
            {
                list = executeSelectSP();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            if (sErr != "") ErrorLog.SetLog(sErr);
            if(list.Rows.Count==1)
				return true;
            return false;
        }
		
		private string CreateWhereClause(GPS_DataInfo obj)
        {
            String result = "";

            return result;
        }
        
        public DataTable Search(string columnName, string columnValue, string condition, ref string sErr)
        {
            string query = "select * from " + _strTableName + " where " + columnName + " " + condition + " " + columnValue;
            DataTable list = new DataTable();
            connect();
            try
            {
                list = executeSelectQuery(query);
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            //if (dr != null) list = CBO.FillCollection(dr, ref list);
            //    if (sErr != "") ErrorLog.SetLog(sErr);
            return list;
        }
		public DataTable GetTransferOut(string dtb, object from, object to, ref string sErr)
        {
            connect();
            InitSPCommand(_strSPGetTransferOutName);
			AddParameter("DB", dtb);
			AddParameter("FROM", from);
			AddParameter("TO", to);
            DataTable list = new DataTable();
            try
            {
                list = executeSelectSP();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();


            if (sErr != "") ErrorLog.SetLog(sErr);
            return list;
        }
        
        public DataTable Getdata(string IDDevices, string StartTime, string StopTime, ref string sErr)
        {
            string query = "[procGPS_Data_get] @StartTime='" + StartTime + "',@StopTime='" + StopTime + "',@IMED_Device='" + IDDevices + "'";
            DataTable list = new DataTable();
            connect();
            try
            {
                list = executeSelectQuery(query);
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            disconnect();
            //if (dr != null) list = CBO.FillCollection(dr, ref list);
            //    if (sErr != "") ErrorLog.SetLog(sErr);
            return list;
        }
		#endregion Method


        
    }
}
