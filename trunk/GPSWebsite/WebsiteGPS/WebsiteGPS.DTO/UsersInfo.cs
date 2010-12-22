using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WebsiteGPS.DTO
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com 
	/// <summary>
	
    public class UsersInfo
    {
		#region Local Variable
		public enum Field
		{
			ID_User,
			Username,
			Password,
			Email,
			Fullname,
			Mobile,
			Company,
			Cop_Phone,
			Status
		}
		private Int32 _ID_User;
		private String _Username;
		private String _Password;
		private String _Email;
		private String _Fullname;
		private Int32 _Mobile;
		private String _Company;
		private Int32 _Cop_Phone;
		private Int32 _Status;
		
		public Int32 ID_User{	get{ return _ID_User;} set{_ID_User = value;} }
		public String Username{	get{ return _Username;} set{_Username = value;} }
		public String Password{	get{ return _Password;} set{_Password = value;} }
		public String Email{	get{ return _Email;} set{_Email = value;} }
		public String Fullname{	get{ return _Fullname;} set{_Fullname = value;} }
		public Int32 Mobile{	get{ return _Mobile;} set{_Mobile = value;} }
		public String Company{	get{ return _Company;} set{_Company = value;} }
		public Int32 Cop_Phone{	get{ return _Cop_Phone;} set{_Cop_Phone = value;} }
		public Int32 Status{	get{ return _Status;} set{_Status = value;} }
		
        #endregion LocalVariable
        
        #region Constructor
		public UsersInfo()
		{
			_ID_User = 0;
			_Username = "";
			_Password = "";
			_Email = "";
			_Fullname = "";
			_Mobile = 0;
			_Company = "";
			_Cop_Phone = 0;
			_Status = 0;
		}
		public UsersInfo(
		Int32 ID_User,
		String Username,
		String Password,
		String Email,
		String Fullname,
		Int32 Mobile,
		String Company,
		Int32 Cop_Phone,
		Int32 Status
		)
		{
			_ID_User = ID_User;
			_Username = Username;
			_Password = Password;
			_Email = Email;
			_Fullname = Fullname;
			_Mobile = Mobile;
			_Company = Company;
			_Cop_Phone = Cop_Phone;
			_Status = Status;
		}
		public UsersInfo(DataRow dr)
		{
			if (dr != null)
			{
				_ID_User = dr[Field.ID_User.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.ID_User.ToString()]);
				_Username = dr[Field.Username.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Username.ToString()]);
				_Password = dr[Field.Password.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Password.ToString()]);
				_Email = dr[Field.Email.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Email.ToString()]);
				_Fullname = dr[Field.Fullname.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Fullname.ToString()]);
				_Mobile = dr[Field.Mobile.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Mobile.ToString()]);
				_Company = dr[Field.Company.ToString()] == DBNull.Value?"":Convert.ToString(dr[Field.Company.ToString()]);
				_Cop_Phone = dr[Field.Cop_Phone.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Cop_Phone.ToString()]);
				_Status = dr[Field.Status.ToString()] == DBNull.Value?0:Convert.ToInt32(dr[Field.Status.ToString()]);
			}
		}
		public UsersInfo(UsersInfo objEntr)
		{			
			_ID_User = objEntr.ID_User;			
			_Username = objEntr.Username;			
			_Password = objEntr.Password;			
			_Email = objEntr.Email;			
			_Fullname = objEntr.Fullname;			
			_Mobile = objEntr.Mobile;			
			_Company = objEntr.Company;			
			_Cop_Phone = objEntr.Cop_Phone;			
			_Status = objEntr.Status;			
		}
        #endregion Constructor
        
        #region InitTable
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("Users");
			dt.Columns.AddRange(new DataColumn[] { 
				new DataColumn(Field.ID_User.ToString(), typeof(Int32)),
				new DataColumn(Field.Username.ToString(), typeof(String)),
				new DataColumn(Field.Password.ToString(), typeof(String)),
				new DataColumn(Field.Email.ToString(), typeof(String)),
				new DataColumn(Field.Fullname.ToString(), typeof(String)),
				new DataColumn(Field.Mobile.ToString(), typeof(Int32)),
				new DataColumn(Field.Company.ToString(), typeof(String)),
				new DataColumn(Field.Cop_Phone.ToString(), typeof(Int32)),
				new DataColumn(Field.Status.ToString(), typeof(Int32))
			});
			return dt;
		}
		public DataRow ToDataRow(DataTable dt)
		{
			DataRow row = dt.NewRow();
			row[Field.ID_User.ToString()] = _ID_User;
			row[Field.Username.ToString()] = _Username;
			row[Field.Password.ToString()] = _Password;
			row[Field.Email.ToString()] = _Email;
			row[Field.Fullname.ToString()] = _Fullname;
			row[Field.Mobile.ToString()] = _Mobile;
			row[Field.Company.ToString()] = _Company;
			row[Field.Cop_Phone.ToString()] = _Cop_Phone;
			row[Field.Status.ToString()] = _Status;
			return row;
		}
        #endregion InitTable
    }
}
