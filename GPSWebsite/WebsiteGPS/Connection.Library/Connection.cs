using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace Agrond.Library.Conection
{
    class Connection
    {
        private SqlCommand _SQLCmd;
        private SqlConnection _SQLCnn;
        private SqlDataAdapter _da;

        //private int ConnectType(String connType)
        //{
        //    try
        //    {
        //        if (connType == "MsSQL")
        //            return 1;
        //        else if (connType == "MySQL")
        //            return 2;
        //        else if (connType == "Access")
        //            return 3;
        //        else return 0;
        //    }
        //    catch (Exception e) { Console.Write(e.ToString()); return 0; }
        //}
        /* This Function use to dispose connect and close connect
         */
        private void DisposeConnect()
        {
            _SQLCnn.Dispose();
            _SQLCnn.Close();
        }
        //This Function use to make connect to databse 
        private void ConnectMsSQL(String strConnect)
        {
            try
            {
                _SQLCnn = new SqlConnection();
                _SQLCnn.ConnectionString = strConnect;
                _SQLCnn.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
                //show error
            }
        }

        /// <summary>
        /// This Function use to execute SQL scalar
        /// </summary>
        /// <param name="strConnect">Connection's String</param>
        /// <param name="strQuery">Query's String</param>
        /// <param name="connType">Type of conection number</param>
        /// <returns>this function return true if connection is executed successfully,It will return false</returns>
        public Boolean ExeMSSQLScalarQuery(String strConnect, String strQuery)
        {
            //open Connect to Mssql
            ConnectMsSQL(strConnect);
            try
            {
                _SQLCmd = _SQLCnn.CreateCommand();
                _SQLCmd.CommandText = strQuery;
                _SQLCmd.ExecuteNonQuery();
                DisposeConnect();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
                return false;
            }
            return true;
        }
        /*This Function use to give data form database to dataset
         * input:   Connection's String
         *          Query's String 
         *          Type of conection number
         *          Name of datatable
         * return: this function return dataset
         */
        public DataTable ReturnDataTable(String strConnect, String strQuery)
        {
            DataTable dtbl = new DataTable();
            //open Connect to Mssql
            ConnectMsSQL(strConnect);
            try
            {
                _SQLCmd = _SQLCnn.CreateCommand();
                _SQLCmd.CommandText = strQuery;
                _da = new SqlDataAdapter(_SQLCmd);
                _da.Fill(dtbl);
                _da.Dispose();
                DisposeConnect();
                return dtbl;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
            }
            return dtbl;
        }
        public Boolean CheckDataIsNull(String strConnect, String strQuery)
        {
            DataTable dsToCheck = new DataTable();
            dsToCheck = ReturnDataTable(strConnect, strQuery);
            if (dsToCheck.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*----------------------------------------------------------------------------*/
        //use for storeproceduce
        public Boolean ExeStoreproceduce(String strConnect, String storeProceduce,
                                        String[] ParameterName, String[] ParameterValue)
        {
            //open Connect to Mssql
            ConnectMsSQL(strConnect);
            try
            {
                _SQLCmd = _SQLCnn.CreateCommand();
                _SQLCmd.CommandType = CommandType.StoredProcedure;
                _SQLCmd.CommandText = storeProceduce;
                for (int i = 0; i < ParameterName.Length; i++)
                {
                    _SQLCmd.Parameters.AddWithValue(ParameterName[i], ParameterValue[i]);
                }
                _SQLCmd.ExecuteNonQuery();
                DisposeConnect();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
                return false;
            }
            return true;
        }
        public DataTable SPReturnDataTable(String strConnect, String storeProceduce,
                                                String ParameterName, String ParameterValue)
        {
            DataTable dtbl = new DataTable();
            //open Connect to Mssql
            ConnectMsSQL(strConnect);
            try
            {
                _SQLCmd = _SQLCnn.CreateCommand();
                _SQLCmd.CommandText = storeProceduce;
                _SQLCmd.CommandType = CommandType.StoredProcedure;
                _SQLCmd.Parameters.AddWithValue(ParameterName, ParameterValue);
                _da = new SqlDataAdapter(_SQLCmd);
                _da.Fill(dtbl);
                _da.Dispose();
                DisposeConnect();
                return dtbl;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
            }
            return dtbl;
        }
        public DataTable SPReturnDataTable(String strConnect, String storeProceduce,
                                                String[] ParameterName, String[] ParameterValue)
        {
            DataTable dtbl = new DataTable();
            //open Connect to Mssql
            ConnectMsSQL(strConnect);
            try
            {
                _SQLCmd = _SQLCnn.CreateCommand();
                _SQLCmd.CommandText = storeProceduce;
                _SQLCmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < ParameterName.Length; i++)
                {
                    _SQLCmd.Parameters.AddWithValue(ParameterName[i], ParameterValue[i]);
                }
                _da = new SqlDataAdapter(_SQLCmd);
                _da.Fill(dtbl);
                _da.Dispose();
                DisposeConnect();
                return dtbl;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                DisposeConnect();
            }
            return dtbl;
        }
    }
}
