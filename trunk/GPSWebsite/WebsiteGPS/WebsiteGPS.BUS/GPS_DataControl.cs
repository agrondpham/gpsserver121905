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
		
        public GPS_DataInfo Get(
        Int32 ID_Data,
		ref string sErr)
        {
            return _objDAO.Get(
            ID_Data,
			ref sErr);
        }
		
        public DataTable GetAll(
        ref string sErr)
        {
            return _objDAO.GetAll(
            ref sErr);
        }
		
        public Int32 Add(GPS_DataInfo obj, ref string sErr)
        {
            return _objDAO.Add(obj, ref sErr);
        }
		
        public string Update(GPS_DataInfo obj)
        {
            return _objDAO.Update(obj);
        }
		
        public string Delete(
        Int32 ID_Data
		)
        {
            return _objDAO.Delete(
            ID_Data
			);
        }  
        public Boolean IsExist(
        Int32 ID_Data
		)
        {
            return _objDAO.IsExist(
            ID_Data
			);
        } 
		      		
		public DataTableCollection Get_Page(GPS_DataInfo obj, string orderBy, int pageIndex, int pageSize,ref String sErr)
        {
            return _objDAO.Get_Page(obj, orderBy, pageIndex, pageSize, ref sErr);
        }
        
        public DataTable Search(String columnName, String columnValue, String condition, ref String sErr)
        {           
            return _objDAO.Search(columnName, columnValue, condition, ref  sErr);
        }
        public string InsertUpdate(GPS_DataInfo obj)
        {
            string sErr = "";
            if (IsExist(
            obj.ID_Data
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
			GPS_DataInfo inf = new GPS_DataInfo();
            return inf.ToDataTable();
        }
		
		public string TransferIn(DataRow row)
        {
            GPS_DataInfo inf = new GPS_DataInfo(row);
            return InsertUpdate(inf);
        }
		#endregion Method

    }
}
