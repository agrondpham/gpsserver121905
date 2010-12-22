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
    public class UsersDataAccess : WebsiteGPS.DAO.Connection
    {
		#region Local Variable
        private string _strSPInsertName = "dbo.[procUsers_add]";
        private string _strSPUpdateName = "dbo.[procUsers_update]";
        private string _strSPDeleteName = "dbo.[procUsers_delete]";
        private string _strSPGetName = "dbo.[procUsers_get]";
        private string _strSPGetAllName = "dbo.[procUsers_getall]";
		private string _strSPGetPages = "dbo.[procUsers_getpaged]";
		private string _strSPIsExist = "dbo.[procUsers_isexist]";
        private string _strTableName = "[Users]";
		private string _strSPGetTransferOutName = "dbo.[procUsers_gettransferout]";
		#endregion Local Variable
		
		#region Method
        public UsersInfo Get(
        Int32 ID_User,
		ref string sErr)
        {
			UsersInfo objEntr = new UsersInfo();
			connect();
			InitSPCommand(_strSPGetName);              
            AddParameter(UsersInfo.Field.ID_User.ToString(), ID_User);
            
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
                objEntr = (UsersInfo)GetDataFromDataRow(list, 0);
            //if (dr != null) list = CBO.FillCollection(dr, ref list);
            if (sErr != "") ErrorLog.SetLog(sErr);
            return objEntr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            UsersInfo result = new UsersInfo();
            result.ID_User = (dt.Rows[i][UsersInfo.Field.ID_User.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][UsersInfo.Field.ID_User.ToString()]));
            result.Username = (dt.Rows[i][UsersInfo.Field.Username.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][UsersInfo.Field.Username.ToString()]));
            result.Password = (dt.Rows[i][UsersInfo.Field.Password.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][UsersInfo.Field.Password.ToString()]));
            result.Email = (dt.Rows[i][UsersInfo.Field.Email.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][UsersInfo.Field.Email.ToString()]));
            result.Fullname = (dt.Rows[i][UsersInfo.Field.Fullname.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][UsersInfo.Field.Fullname.ToString()]));
            result.Mobile = (dt.Rows[i][UsersInfo.Field.Mobile.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][UsersInfo.Field.Mobile.ToString()]));
            result.Company = (dt.Rows[i][UsersInfo.Field.Company.ToString()] == DBNull.Value ? "" : Convert.ToString(dt.Rows[i][UsersInfo.Field.Company.ToString()]));
            result.Cop_Phone = (dt.Rows[i][UsersInfo.Field.Cop_Phone.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][UsersInfo.Field.Cop_Phone.ToString()]));
            result.Status = (dt.Rows[i][UsersInfo.Field.Status.ToString()] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i][UsersInfo.Field.Status.ToString()]));
           
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
        public Int32 Add(UsersInfo objEntr, ref string sErr)
        {
            int ret = -1;
            connect();
            InitSPCommand(_strSPInsertName);
            AddParameter(UsersInfo.Field.Username.ToString(), objEntr.Username);
            AddParameter(UsersInfo.Field.Password.ToString(), objEntr.Password);
            AddParameter(UsersInfo.Field.Email.ToString(), objEntr.Email);
            AddParameter(UsersInfo.Field.Fullname.ToString(), objEntr.Fullname);
            AddParameter(UsersInfo.Field.Mobile.ToString(), objEntr.Mobile);
            AddParameter(UsersInfo.Field.Company.ToString(), objEntr.Company);
            AddParameter(UsersInfo.Field.Cop_Phone.ToString(), objEntr.Cop_Phone);
            AddParameter(UsersInfo.Field.Status.ToString(), objEntr.Status);
          
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

        public string Update(UsersInfo objEntr)
        {
            connect();
            InitSPCommand(_strSPUpdateName);
            AddParameter(UsersInfo.Field.ID_User.ToString(), objEntr.ID_User);
            AddParameter(UsersInfo.Field.Username.ToString(), objEntr.Username);
            AddParameter(UsersInfo.Field.Password.ToString(), objEntr.Password);
            AddParameter(UsersInfo.Field.Email.ToString(), objEntr.Email);
            AddParameter(UsersInfo.Field.Fullname.ToString(), objEntr.Fullname);
            AddParameter(UsersInfo.Field.Mobile.ToString(), objEntr.Mobile);
            AddParameter(UsersInfo.Field.Company.ToString(), objEntr.Company);
            AddParameter(UsersInfo.Field.Cop_Phone.ToString(), objEntr.Cop_Phone);
            AddParameter(UsersInfo.Field.Status.ToString(), objEntr.Status);
               
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
        Int32 ID_User
		)
        {
            connect();
            InitSPCommand(_strSPDeleteName);
            AddParameter(UsersInfo.Field.ID_User.ToString(), ID_User);
              
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
		
		public DataTableCollection Get_Page(UsersInfo obj, string orderBy, int pageIndex, int pageSize, ref String sErr)
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
        Int32 ID_User
		)
        {
            connect();
            InitSPCommand(_strSPIsExist);
            AddParameter(UsersInfo.Field.ID_User.ToString(), ID_User);
              
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
		
		private string CreateWhereClause(UsersInfo obj)
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
