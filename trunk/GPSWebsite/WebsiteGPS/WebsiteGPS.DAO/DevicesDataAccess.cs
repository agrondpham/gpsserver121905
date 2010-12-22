using System;
using System.Collections.Generic;
using System.Text;
using WebsiteGPS.DTO;
using System.Data;
using System.Data.SqlClient;


namespace WebsiteGPS.DAO
{
	/// <summary> 
	///Author: nnamthach@gmail.com 
	/// <summary>
    public class DevicesDataAccess : WebsiteGPS.DAO.Connection
    {
		#region Local Variable
        private string _strSPInsertName = "dbo.[procDevices_add]";
        private string _strSPUpdateName = "dbo.[procDevices_update]";
        private string _strSPDeleteName = "dbo.[procDevices_delete]";
        private string _strSPGetName = "dbo.[procDevices_get]";
        private string _strSPGetAllName = "dbo.[procDevices_getall]";
		private string _strSPGetPages = "dbo.[procDevices_getpaged]";
		private string _strSPIsExist = "dbo.[procDevices_isexist]";
        private string _strTableName = "[Devices]";
		private string _strSPGetTransferOutName = "dbo.[procDevices_gettransferout]";
		#endregion Local Variable
		
		#region Method
        public DevicesInfo Get(
        Int32 IMED_Device,
		ref string sErr)
        {
			DevicesInfo objEntr = new DevicesInfo();
			connect();
			InitSPCommand(_strSPGetName);              
            AddParameter(DevicesInfo.Field.IMED_Device.ToString(), IMED_Device);
            
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
                objEntr = (DevicesInfo)GetDataFromDataRow(list, 0);
            //if (dr != null) list = CBO.FillCollection(dr, ref list);
            if (sErr != "") WebsiteGPS.DAO.ErrorLog.SetLog(sErr);
            return objEntr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DevicesInfo result = new DevicesInfo();
            result.IMED_Device = (dt.Rows[i][DevicesInfo.Field.IMED_Device.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][DevicesInfo.Field.IMED_Device.ToString()]));
            result.ID_User = (dt.Rows[i][DevicesInfo.Field.ID_User.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][DevicesInfo.Field.ID_User.ToString()]));
            result.Status = (dt.Rows[i][DevicesInfo.Field.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][DevicesInfo.Field.Status.ToString()]));
           
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
        public Int32 Add(DevicesInfo objEntr, ref string sErr)
        {
            int ret = -1;
            connect();
            InitSPCommand(_strSPInsertName);
            AddParameter(DevicesInfo.Field.IMED_Device.ToString(), objEntr.IMED_Device);
            AddParameter(DevicesInfo.Field.ID_User.ToString(), objEntr.ID_User);
            AddParameter(DevicesInfo.Field.Status.ToString(), objEntr.Status);
          
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

        public string Update(DevicesInfo objEntr)
        {
            connect();
            InitSPCommand(_strSPUpdateName);
            AddParameter(DevicesInfo.Field.IMED_Device.ToString(), objEntr.IMED_Device);
            AddParameter(DevicesInfo.Field.ID_User.ToString(), objEntr.ID_User);
            AddParameter(DevicesInfo.Field.Status.ToString(), objEntr.Status);
               
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
        Int32 IMED_Device
		)
        {
            connect();
            InitSPCommand(_strSPDeleteName);
            AddParameter(DevicesInfo.Field.IMED_Device.ToString(), IMED_Device);
              
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
		
		public DataTableCollection Get_Page(DevicesInfo obj, string orderBy, int pageIndex, int pageSize, ref String sErr)
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
        Int32 IMED_Device
		)
        {
            connect();
            InitSPCommand(_strSPIsExist);
            AddParameter(DevicesInfo.Field.IMED_Device.ToString(), IMED_Device);
              
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
		
		private string CreateWhereClause(DevicesInfo obj)
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
		#endregion Method
     
    }
}
