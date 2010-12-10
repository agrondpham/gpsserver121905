﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Data.Sql;
namespace DAO
{
    public class Connection
    {
        protected static string _connectionString = ConfigurationSettings.AppSettings["strConnection"].ToString();
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;
        protected SqlTransaction trans;

        public Connection()
        {
            connection = new SqlConnection(_connectionString);
        }
        public static void CreateConnectString(string server, string username, string pass, string database)
        {
            string result = "Data Source=" + server + ";Initial Catalog=" + database + ";User ID=" + username + ";Password=" + pass + ";Connect Timeout=500";
            _connectionString = result;
        }

        public static DataTable GetServers()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public static DataTable GetDataBases(String Server, String Username, String Pass)
        {
            SqlConnection conn = null;
            try
            {
                //Server=.;Database=SiteCamera;uid=sa;pwd=qawsed;Connection Lifetime=100;Connect Timeout=500
                string connectString = "Server=" + Server + "; uid=" + Username + ";pwd=" + Pass + "; Connection Lifetime=100;Connect Timeout=500";
                conn = new SqlConnection(connectString);
                conn.Open();
                DataTable dt = conn.GetSchema("Databases");
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();
                return null;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        public bool TestConnect()
        {
            bool flag = true;
            try
            {
                connect();
                disconnect();
            }
            catch
            {
                flag = false;

            }
            return flag;
        }
        public void connect()
        {
            connection = new SqlConnection(_connectionString);
            command = new SqlCommand();
            connection.Open();
        }
        public bool BeginTransaction(ref String sErr)
        {
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand();
                command.Connection = connection;
                trans = connection.BeginTransaction();
                command.Transaction = trans;
                return true;
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
        }
        public bool CommitTransaction(ref String sErr)
        {
            try
            {
                trans.Commit();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    trans.Rollback();
                    sErr = e.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    sErr = ex.Message;
                    return false;
                }
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Thêm tham số vào command
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void AddParameter(string name, object value)
        {
            SqlParameter para = command.CreateParameter();
            para.ParameterName = name;
            para.SqlValue = value;
            command.Parameters.Add(para);
        }
        public static Byte[] ConvertImageToByte(Image value)
        {
            // string filename = ".\\Template\\" +Convert.ToString(DateTime.Now.ToFileTime());
            // value.Save(filename);
            // FileInfo fileInfo = new FileInfo(filename);
            // FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            // Byte[] barrImg = new Byte[Convert.ToInt32(fileInfo.Length)];
            // int iBytesRead = fs.Read(barrImg, 0,
            //              Convert.ToInt32(fileInfo.Length));
            //// File.Delete(filename);
            // fs.Close();
            MemoryStream ms = new MemoryStream();
            value.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Byte[] barrImg = ms.ToArray();
            return barrImg;
        }
        public static Image ConvertByteToImage(Byte[] value)
        {
            //string filename = ".\\Template\\" + Convert.ToString(DateTime.Now.ToFileTime());
            //FileStream fs = new FileStream(filename, FileMode.CreateNew, FileAccess.ReadWrite);
            //fs.Write(value, 0, value.Length);
            //fs.Flush();
            //fs.Close();
            MemoryStream fs = new MemoryStream(value);
            Image kq = Image.FromStream(fs);
            //File.Delete(filename);
            return kq;
        }
        protected void AddParameterImage(string name, System.Drawing.Image value)
        {
            SqlParameter para = command.CreateParameter();
            para.ParameterName = name;
            Byte[] barrImg = ConvertImageToByte(value);
            para.SqlValue = barrImg;
            command.Parameters.Add(para);
        }

        /// <summary>
        /// Thêm mảng tham số vào command
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void AddParameters(SqlParameter[] arrParam)
        {
            for (int i = 0; i < arrParam.Length; i++)
                command.Parameters.Add(arrParam[i]);
        }

        /// <summary>
        /// Tạo mảng tham số
        /// </summary>
        /// <param name="objEntr"></param>
        /// <returns></returns>
        protected virtual void GetParammeter(object objEntr)
        {
            return;
        }
        protected virtual void InitSPCommand(string strCommandText)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = strCommandText;
        }

        public void disconnect()
        {
            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Them tham so vao SP_command
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>

        public IDataReader executeQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteReader();
        }
        public DataTable executeSelectQuery(string sqlString)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(sqlString, connection);
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable executeSelectSP()
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable executeSelectSP(SqlCommand command)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTableCollection executeCollectSelectSP(SqlCommand command)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables;
        }
        public DataTableCollection executeCollectSelectSP()
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables;
        }
        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();
        }
        public object executeSPScalar()
        {
            return command.ExecuteScalar();
        }
        public object executeSPScalar(SqlCommand command)
        {
            return command.ExecuteScalar();
        }
        public void excuteSPNonQuery()
        {
            command.ExecuteNonQuery();
        }
        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }
        public object executeStoreProcedure()
        {
            object result = null;
            try
            {
                result = command.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Chuyển một dòng dữ liệu thành một đối tượng tương ứng với lớp kế thừa
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {

            return null;
        }
        protected ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            ArrayList arr = new ArrayList();
            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object hs = GetDataFromDataRow(dt, i);
                arr.Add(hs);

            }
            return arr;
        }
        protected ArrayList ConvertDataTableToArrayList(DataTable dt)
        {
            ArrayList arr = new ArrayList();
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object hs = GetDataFromDataRow(dt, i);
                arr.Add(hs);
            }
            return arr;
        }
        protected Object[] ConvertDataSetToArray(DataSet dataset)
        {
            DataTable dt = dataset.Tables[0];
            Object[] arr = new Object[dt.Rows.Count];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object hs = GetDataFromDataRow(dt, i);
                arr[i] = hs;
            }
            return arr;
        }
        protected Object[] ConvertDataTableToArray(DataTable dt)
        {
            Object[] arr = new Object[dt.Rows.Count];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object hs = GetDataFromDataRow(dt, i);
                arr[i] = hs;
            }
            return arr;
        }
        public DateTime GetDateSys()
        {
            connect();
            object date = executeScalar("sp_GetSysDate");
            disconnect();
            return (DateTime)date;
        }
    }
}
