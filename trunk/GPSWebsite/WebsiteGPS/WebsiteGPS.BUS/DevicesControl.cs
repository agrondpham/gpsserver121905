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
    public class DevicesControl
    {
		#region Local Variable
        private DevicesDataAccess _objDAO;
		#endregion Local Variable
		
		#region Method
        public DevicesControl()
        {
            _objDAO = new DevicesDataAccess();
        }
		
        public DevicesInfo Get(
        Int32 IMED_Device,
		ref string sErr)
        {
            return _objDAO.Get(
            IMED_Device,
			ref sErr);
        }
		
        public DataTable GetAll(
        ref string sErr)
        {
            return _objDAO.GetAll(
            ref sErr);
        }
		
        public Int32 Add(DevicesInfo obj, ref string sErr)
        {
            return _objDAO.Add(obj, ref sErr);
        }
		
        public string Update(DevicesInfo obj)
        {
            return _objDAO.Update(obj);
        }
		
        public string Delete(
        Int32 IMED_Device
		)
        {
            return _objDAO.Delete(
            IMED_Device
			);
        }  
        public Boolean IsExist(
        Int32 IMED_Device
		)
        {
            return _objDAO.IsExist(
            IMED_Device
			);
        } 
		      		
		public DataTableCollection Get_Page(DevicesInfo obj, string orderBy, int pageIndex, int pageSize,ref String sErr)
        {
            return _objDAO.Get_Page(obj, orderBy, pageIndex, pageSize, ref sErr);
        }
        
        public DataTable Search(String columnName, String columnValue, String condition, ref String sErr)
        {           
            return _objDAO.Search(columnName, columnValue, condition, ref  sErr);
        }
        public string InsertUpdate(DevicesInfo obj)
        {
            string sErr = "";
            if (IsExist(
            obj.IMED_Device
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
			DevicesInfo inf = new DevicesInfo();
            return inf.ToDataTable();
        }
		
		public string TransferIn(DataRow row)
        {
            DevicesInfo inf = new DevicesInfo(row);
            return InsertUpdate(inf);
        }
		#endregion Method

    }
}
