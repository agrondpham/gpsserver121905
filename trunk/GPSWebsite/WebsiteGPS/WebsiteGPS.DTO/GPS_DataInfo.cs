using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WebsiteGPS.DTO
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com 
	/// <summary>
	
    public class GPS_DataInfo
    {
		#region Local Variable
		public enum Field
		{
			ID_Data,
			IMED_Device,
			Longitude,
			Latitude,
			Speed,
			Received_Data,
			Status
		}
		private Int32 _ID_Data;
		private Int32 _IMED_Device;
		private Double _Longitude;
		private Double _Latitude;
		private Double _Speed;
		private String _Received_Data;
		private Int32 _Status;
		
		public Int32 ID_Data{	get{ return _ID_Data;} set{_ID_Data = value;} }
		public Int32 IMED_Device{	get{ return _IMED_Device;} set{_IMED_Device = value;} }
		public Double Longitude{	get{ return _Longitude;} set{_Longitude = value;} }
		public Double Latitude{	get{ return _Latitude;} set{_Latitude = value;} }
		public Double Speed{	get{ return _Speed;} set{_Speed = value;} }
		public String Received_Data{	get{ return _Received_Data;} set{_Received_Data = value;} }
		public Int32 Status{	get{ return _Status;} set{_Status = value;} }
		
        #endregion LocalVariable
        
        #region Constructor
		public GPS_DataInfo()
		{
			_ID_Data = 0;
			_IMED_Device = 0;
			_Longitude = 0;
			_Latitude = 0;
			_Speed = 0;
			_Received_Data = "";
			_Status = 0;
		}
		public GPS_DataInfo(
		Int32 ID_Data,
		Int32 IMED_Device,
		Double Longitude,
		Double Latitude,
		Double Speed,
		String Received_Data,
		Int32 Status
		)
		{
			_ID_Data = ID_Data;
			_IMED_Device = IMED_Device;
			_Longitude = Longitude;
			_Latitude = Latitude;
			_Speed = Speed;
			_Received_Data = Received_Data;
			_Status = Status;
		}
		public GPS_DataInfo(DataRow dr)
		{
			if (dr != null)
			{
				_ID_Data = dr[Field.ID_Data.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.ID_Data.ToString()]);
				_IMED_Device = dr[Field.IMED_Device.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.IMED_Device.ToString()]);
				_Longitude = dr[Field.Longitude.ToString()] == DBNull.Value?0:Convert.ToDouble(dr[Field.Longitude.ToString()]);
				_Latitude = dr[Field.Latitude.ToString()] == DBNull.Value?0:Convert.ToDouble(dr[Field.Latitude.ToString()]);
				_Speed = dr[Field.Speed.ToString()] == DBNull.Value?0:Convert.ToDouble(dr[Field.Speed.ToString()]);
				_Received_Data = dr[Field.Received_Data.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Received_Data.ToString()]);
				_Status = dr[Field.Status.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Status.ToString()]);
			}
		}
		public GPS_DataInfo(GPS_DataInfo objEntr)
		{			
			_ID_Data = objEntr.ID_Data;			
			_IMED_Device = objEntr.IMED_Device;			
			_Longitude = objEntr.Longitude;			
			_Latitude = objEntr.Latitude;			
			_Speed = objEntr.Speed;			
			_Received_Data = objEntr.Received_Data;			
			_Status = objEntr.Status;			
		}
        #endregion Constructor
        
        #region InitTable
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("GPS_Data");
			dt.Columns.AddRange(new DataColumn[] { 
				new DataColumn(Field.ID_Data.ToString(), typeof(Int32)),
				new DataColumn(Field.IMED_Device.ToString(), typeof(Int32)),
				new DataColumn(Field.Longitude.ToString(), typeof(Double)),
				new DataColumn(Field.Latitude.ToString(), typeof(Double)),
				new DataColumn(Field.Speed.ToString(), typeof(Double)),
				new DataColumn(Field.Received_Data.ToString(), typeof(String)),
				new DataColumn(Field.Status.ToString(), typeof(Int32))
			});
			return dt;
		}
		public DataRow ToDataRow(DataTable dt)
		{
			DataRow row = dt.NewRow();
			row[Field.ID_Data.ToString()] = _ID_Data;
			row[Field.IMED_Device.ToString()] = _IMED_Device;
			row[Field.Longitude.ToString()] = _Longitude;
			row[Field.Latitude.ToString()] = _Latitude;
			row[Field.Speed.ToString()] = _Speed;
			row[Field.Received_Data.ToString()] = _Received_Data;
			row[Field.Status.ToString()] = _Status;
			return row;
		}
        #endregion InitTable
    }
}
