using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WebsiteGPS.DTO
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com 
	/// <summary>
	
    public class DevicesInfo
    {
		#region Local Variable
		public enum Field
		{
			IMED_Device,
			ID_User,
			Status
		}
		private Int32 _IMED_Device;
		private Int32 _ID_User;
		private Int32 _Status;
		
		public Int32 IMED_Device{	get{ return _IMED_Device;} set{_IMED_Device = value;} }
		public Int32 ID_User{	get{ return _ID_User;} set{_ID_User = value;} }
		public Int32 Status{	get{ return _Status;} set{_Status = value;} }
		
        #endregion LocalVariable
        
        #region Constructor
		public DevicesInfo()
		{
			_IMED_Device = 0;
			_ID_User = 0;
			_Status = 0;
		}
		public DevicesInfo(
		Int32 IMED_Device,
		Int32 ID_User,
		Int32 Status
		)
		{
			_IMED_Device = IMED_Device;
			_ID_User = ID_User;
			_Status = Status;
		}
		public DevicesInfo(DataRow dr)
		{
			if (dr != null)
			{
				_IMED_Device = dr[Field.IMED_Device.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.IMED_Device.ToString()]);
				_ID_User = dr[Field.ID_User.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.ID_User.ToString()]);
				_Status = dr[Field.Status.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Status.ToString()]);
			}
		}
		public DevicesInfo(DevicesInfo objEntr)
		{			
			_IMED_Device = objEntr.IMED_Device;			
			_ID_User = objEntr.ID_User;			
			_Status = objEntr.Status;			
		}
        #endregion Constructor
        
        #region InitTable
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("Devices");
			dt.Columns.AddRange(new DataColumn[] { 
				new DataColumn(Field.IMED_Device.ToString(), typeof(Int32)),
				new DataColumn(Field.ID_User.ToString(), typeof(Int32)),
				new DataColumn(Field.Status.ToString(), typeof(Int32))
			});
			return dt;
		}
		public DataRow ToDataRow(DataTable dt)
		{
			DataRow row = dt.NewRow();
			row[Field.IMED_Device.ToString()] = _IMED_Device;
			row[Field.ID_User.ToString()] = _ID_User;
			row[Field.Status.ToString()] = _Status;
			return row;
		}
        #endregion InitTable
    }
}
