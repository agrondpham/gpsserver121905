using System;
using System.Collections.Generic;
using System.Text;
using WebsiteGPS.DTO;
using WebsiteGPS.DAO;
using System.Data;


namespace WebsiteGPS.BUS
{
	/// <summary> 
	///Author: nnamthach@gmail.com 
	/// <summary>
    public class UsersControl
    {
		#region Local Variable
        private UsersDataAccess _objDAO;
		#endregion Local Variable
		
		#region Method
        public UsersControl()
        {
            _objDAO = new UsersDataAccess();
        }
		
        public UsersInfo Get(
        Int32 ID_User,
		ref string sErr)
        {
            return _objDAO.Get(
            ID_User,
			ref sErr);
        }
		
        public DataTable GetAll(
        ref string sErr)
        {
            return _objDAO.GetAll(
            ref sErr);
        }
		
        public Int32 Add(UsersInfo obj, ref string sErr)
        {
            return _objDAO.Add(obj, ref sErr);
        }
		
        public string Update(UsersInfo obj)
        {
            return _objDAO.Update(obj);
        }
		
        public string Delete(
        Int32 ID_User
		)
        {
            return _objDAO.Delete(
            ID_User
			);
        }  
        public Boolean IsExist(
        Int32 ID_User
		)
        {
            return _objDAO.IsExist(
            ID_User
			);
        } 
		      		
		public DataTableCollection Get_Page(UsersInfo obj, string orderBy, int pageIndex, int pageSize,ref String sErr)
        {
            return _objDAO.Get_Page(obj, orderBy, pageIndex, pageSize, ref sErr);
        }
        
        public DataTable Search(String columnName, String columnValue, String condition, ref String sErr)
        {           
            return _objDAO.Search(columnName, columnValue, condition, ref  sErr);
        }
        public string InsertUpdate(UsersInfo obj)
        {
            string sErr = "";
            if (IsExist(
            obj.ID_User
			))
            {
                sErr = Update(obj);
            }
            else
                Add(obj, ref sErr);
            return sErr;
        }
		
        public DataTable GetTransferOut(string dtb, object from, object to, ref string sErr)
        {
            return _objDAO.GetTransferOut(dtb, from, to, ref sErr);
        }

        public DataTable ToTransferInStruct()
        {
			UsersInfo inf = new UsersInfo();
            return inf.ToDataTable();
        }
		
		public string TransferIn(DataRow row)
        {
            UsersInfo inf = new UsersInfo(row);
            return InsertUpdate(inf);
        }
		#endregion Method

    }
}
