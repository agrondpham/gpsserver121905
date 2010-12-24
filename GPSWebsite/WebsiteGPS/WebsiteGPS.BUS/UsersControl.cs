using System;
using System.Collections.Generic;
using System.Text;
using WebsiteGPS.DTO;
using WebsiteGPS.DAO;
using System.Data;
using System.Security.Cryptography;
using System.Net.Mail;

namespace WebsiteGPS.BUS
{
	/// <summary> 
	///Author: daiduong19051986@gmail.com  
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
        String Username,
		ref string sErr)
        {
            return _objDAO.Get(
            Username,
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
        String Username
		)
        {
            return _objDAO.Delete(
            Username
			);
        }  
        public Boolean IsExist(
        String Username
		)
        {
            return _objDAO.IsExist(
            Username
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
            obj.Username
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

        /// <summary>
        /// Ma hoa MD5
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }   
		#endregion Method

    }
}
