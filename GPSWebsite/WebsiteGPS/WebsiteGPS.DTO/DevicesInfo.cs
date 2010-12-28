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
			Username,
			Status
		}
		private Int32 _IMED_Device;
		private String _Username;
		private Int32 _Status;
		
		public Int32 IMED_Device{	get{ return _IMED_Device;} set{_IMED_Device = value;} }
		public String Username{	get{ return _Username;} set{_Username = value;} }
		public Int32 Status{	get{ return _Status;} set{_Status = value;} }
		
        #endregion LocalVariable
        
        #region Constructor
		public DevicesInfo()
		{
			_IMED_Device = 0;
			_Username = "";
			_Status = 0;
		}
		public DevicesInfo(
		Int32 IMED_Device,
		String Username,
		Int32 Status
		)
		{
			_IMED_Device = IMED_Device;
			_Username = Username;
			_Status = Status;
		}
		public DevicesInfo(DataRow dr)
		{
			if (dr != null)
			{
				_IMED_Device = dr[Field.IMED_Device.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.IMED_Device.ToString()]);
				_Username = dr[Field.Username.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Username.ToString()]);
				_Status = dr[Field.Status.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Status.ToString()]);
			}
		}
		public DevicesInfo(DevicesInfo objEntr)
		{			
			_IMED_Device = objEntr.IMED_Device;			
			_Username = objEntr.Username;			
			_Status = objEntr.Status;			
		}
        #endregion Constructor
        
        #region InitTable
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("Devices");
			dt.Columns.AddRange(new DataColumn[] { 
				new DataColumn(Field.IMED_Device.ToString(), typeof(Int32)),
				new DataColumn(Field.Username.ToString(), typeof(String)),
				new DataColumn(Field.Status.ToString(), typeof(Int32))
			});
			return dt;
		}
		public DataRow ToDataRow(DataTable dt)
		{
			DataRow row = dt.NewRow();
			row[Field.IMED_Device.ToString()] = _IMED_Device;
			row[Field.Username.ToString()] = _Username;
			row[Field.Status.ToString()] = _Status;
			return row;
		}
        #endregion InitTable
    }
}
