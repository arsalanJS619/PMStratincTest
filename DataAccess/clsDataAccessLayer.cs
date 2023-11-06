using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    /*
    public struct SqlParamData
    {
        public string pName, pValue;
        public SqlDbType pDataType;
        public ParameterDirection pDirection;
        public SqlParamData(string pName, SqlDbType pDataType, string pValue, ParameterDirection pDirection)
        {
            this.pName = pName;
            this.pDataType = pDataType;
            this.pValue = pValue;
            this.pDirection = pDirection;
        }
    }

    public struct MySqlParamData
    {
        public string pName, pValue;
        public MySqlDbType pDataType;
        public ParameterDirection pDirection;
        public MySqlParamData(string pName, MySqlDbType pDataType, string pValue, ParameterDirection pDirection)
        {
            this.pName = pName;
            this.pDataType = pDataType;
            this.pValue = pValue;
            this.pDirection = pDirection;
        }
    }
    */

    public class clsDataAccessLayer : Object
    {
        #region Variables Declaration

        #region SQL
        protected SqlCommand mobjSqlCommand;
        protected SqlConnection mobjSqlConection;
        protected SqlDataAdapter mobjSqlAdapter;
        protected SqlDataReader mobjSqlDataReader;
        protected SqlException mobjException;
        #endregion

       
        protected string msConnectionString;
        protected string msConnectionType;
        protected DataTable mdtTable;
        protected DataSet mdsDataSet;
        protected string msQuery;

        public enum enumConnectionType
        {
            MSSQL = '1',
            MYSQL = '2'
        };

        #endregion

        /// SUMMARY : GET DATABASE CONNECTION AND TYPE
        /// PARAMETER : NONE
        /// RETURN : NONE
        #region DataBase Settings
        private void LoadDataBaseSettings()
        {

            //string CoDBID = System.Web.HttpContext.Current.Session["CompanyDBID"].ToString();
            ////ConfigurationManager.AppSettings["ConnectionString"].ToString();
            //if (ConfigurationSettings.AppSettings["ConnectionType"] != null)
            //{
            //    msConnectionType = ConfigurationSettings.AppSettings["ConnectionType"].ToString();
            //}
            //if (CoDBID == "2")
            //{
            //    if (ConfigurationSettings.AppSettings["HMMConnectionString"] != null)
            //    {
            //        msConnectionString = ConfigurationSettings.AppSettings["HMMConnectionString"].ToString();
            //    }
            //}
            //else

            //       if (ConfigurationSettings.AppSettings["ConnectionString"] != null)
            //     {

            msConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //msConnectionString = @"Server = DESKTOP-OB15B6M\MSSQLSERVERTEST; Database = dbo; Integrated Security = True;";
            
            
            
            
            // ConfigurationSettings.AppSettings["ConnectionString"].ToString();
             //   }
            
         //   msConnectionType = msConnectionType.Trim().ToLower();
           // if (msConnectionType.Equals("mssql2k"))
   //             msConnectionType = enumConnectionType.MSSQL.ToString();
     //       else if (msConnectionType.Equals("mssql"))
       //         msConnectionType = enumConnectionType.MSSQL.ToString();
         //   else if (msConnectionType.Equals("mysql"))
                msConnectionType = enumConnectionType.MSSQL.ToString();
        }
        #endregion

        /// SUMMARY : CONSTRUCTOR INITIALIZE PARAMETERS
        /// PARAMETER : NONE
        /// RETURN : NONE
        #region Constructor/Destructor
        public clsDataAccessLayer()
        {
            LoadDataBaseSettings();

          //  if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
         //   {
                mobjSqlCommand = new SqlCommand();
                mobjSqlConection = new SqlConnection(msConnectionString);
                mobjSqlCommand.Connection = mobjSqlConection;
                msConnectionString = string.Empty;
                msQuery = string.Empty;
                mobjSqlAdapter = new SqlDataAdapter();
                mdsDataSet = new DataSet();
           // }
            //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
            //{
            //    mobjMySqlCommand = new MySqlCommand();
            //    mobjMySqlConection = new MySqlConnection(msConnectionString);
            //    mobjMySqlCommand.Connection = mobjMySqlConection;
            //    msConnectionString = string.Empty;
            //    msQuery = string.Empty;
            //    mobjMySqlAdapter = new MySqlDataAdapter();
            //    mdsDataSet = new DataSet();
            //}
        }
        #endregion

        #region open / close DataBase
        /// SUMMARY : OPEN DATABASE
        /// PARAMETER : NONE
        /// RETURN : NONE
        public bool OpenDataBase()
        {
            try
            {
                if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                {
                    if (mobjSqlConection.State == ConnectionState.Closed)
                        mobjSqlConection.Open();
                    return true;
                }
                //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
                //{
                //    if (mobjMySqlConection.State == ConnectionState.Closed)
                //        mobjMySqlConection.Open();
                //    return true;
                //}
                return false;
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
                return false;
                //throw (new System.Exception);
            }
        }

        /// SUMMARY : CLOSE DATABASE
        /// PARAMETER : NONE
        /// RETURN : NONE
        public bool CloseDataBase()
        {
            try
            {
                if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                {
                    if (mobjSqlConection != null)
                    {
                        if (mobjSqlConection.State == ConnectionState.Open)
                        {
                            mobjSqlConection.Close();
                            mobjSqlConection.Dispose();
                        }
                    }
                    return true;
                }
                else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
                {
                    //if (mobjMySqlConection != null)
                    //{
                    //    if (mobjMySqlConection.State == ConnectionState.Open)
                    //    {
                    //        mobjMySqlConection.Close();
                    //        mobjMySqlConection.Dispose();
                    //    }
                    //}
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
                return false;
                //throw (new System.Exception);
            }
        }
        #endregion

        #region Data Fetching/Manuplation Methods
        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : QUERY STRING
        /// RETURN : DATATABLE
        public DataTable ExecuteDataTable(string rQry)
        {
            msQuery = rQry;
            mdsDataSet = new DataSet();
            mdtTable = new DataTable();
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                    {
                        mobjSqlCommand.CommandType = CommandType.Text;
                        mobjSqlCommand.CommandText = msQuery;
                        mobjSqlCommand.Connection = mobjSqlConection;
                        //mobjSqlCommand.CommandTimeout = 10000;
                        mobjSqlCommand.CommandTimeout = 0;// 0 = give it as much time as it needs to complete
                        mobjSqlAdapter.SelectCommand = mobjSqlCommand;
                        mobjSqlAdapter.Fill(mdsDataSet, mobjSqlCommand.CommandText);
                    }
                    //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
                    //{
                    //    mobjMySqlCommand.CommandType = CommandType.Text;
                    //    mobjMySqlCommand.CommandText = msQuery;
                    //    mobjMySqlCommand.Connection = mobjMySqlConection;
                    //    //mobjMySqlCommand.CommandTimeout = 10000;
                    //    mobjMySqlCommand.CommandTimeout = 0;// 0 = give it as much time as it needs to complete
                    //    //cmd.CommandTimeout = 0;// 0 = give it as much time as it needs to complete
                    //    mobjMySqlAdapter.SelectCommand = mobjMySqlCommand;
                    //    mobjMySqlAdapter.Fill(mdsDataSet, mobjMySqlCommand.CommandText);
                    //}
                    if (mdsDataSet != null && mdsDataSet.Tables.Count > 0)
                        mdtTable = mdsDataSet.Tables[0];
                    return mdtTable;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return null;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return null;
            }
        }

        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : SQL COMMAND
        /// RETURN : DATATABLE
        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            msQuery = cmd.CommandText;
            mdsDataSet = new DataSet();
            mdtTable = new DataTable();
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    cmd.Connection = mobjSqlConection;
                    //ayaz added for query execution time                  
                    cmd.CommandTimeout = 0;// 0 = give it as much time as it needs to complete
                    mobjSqlAdapter.SelectCommand = cmd;
                    mobjSqlAdapter.Fill(mdsDataSet, cmd.CommandText);
                    if (mdsDataSet != null && mdsDataSet.Tables.Count > 0)
                        mdtTable = mdsDataSet.Tables[0];
                    return mdtTable;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return null;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return null;
            }
        }

        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : SQL COMMAND
        /// RETURN : DATATABLE
        public DataTable ExecuteDataTable(SqlCommand cmd, int iPageSize, int iPageNum, out long iTotalRec)
        {
            iTotalRec = 0;
            msQuery = cmd.CommandText;
            mdsDataSet = new DataSet();
            mdtTable = new DataTable();
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    cmd.Connection = mobjSqlConection;
                    mobjSqlAdapter.SelectCommand = cmd;
                    mobjSqlAdapter.Fill(mdsDataSet, (iPageNum - 1) * iPageSize, iPageSize, "tbl");
                    if (mdsDataSet != null && mdsDataSet.Tables.Count > 0)
                        mdtTable = mdsDataSet.Tables[0];
                    return mdtTable;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return null;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return null;
            }
        }

        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : MYSQL COMMAND
        /// RETURN : DATATABLE
        //public DataTable ExecuteDataTable(MySqlCommand cmd)
        //{
        //    msQuery = cmd.CommandText;
        //    mdsDataSet = new DataSet();
        //    mdtTable = new DataTable();
        //    if (msQuery != "" || msQuery != string.Empty || msQuery != null)
        //    {

        //        try
        //        {
        //            OpenDataBase();
        //            cmd.Connection = mobjMySqlConection;
        //            mobjMySqlAdapter.SelectCommand = cmd;
        //            mobjMySqlAdapter.Fill(mdsDataSet, cmd.CommandText);
        //            if (mdsDataSet != null && mdsDataSet.Tables.Count > 0)
        //                mdtTable = mdsDataSet.Tables[0];
        //            return mdtTable;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //            throw;
        //            return null;
        //        }
        //        finally
        //        {
        //            //CloseDataBase();
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : QUERY STRING, COMMAND PARAMS LIST
        /// RETURN : DATATABLE
        public DataTable ExecuteDataTable(string strQuery, Dictionary<string, object> dicObjParams)
        {
            mdtTable = new DataTable();
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    mobjSqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                mdtTable = this.ExecuteDataTable(mobjSqlCommand);
            }
            //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
            //{
            //    mobjMySqlCommand = new MySqlCommand(strQuery);
            //    foreach (KeyValuePair<string, object> pair in dicObjParams)
            //    {
            //        mobjMySqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
            //    }
            //    mdtTable = this.ExecuteDataTable(mobjMySqlCommand);
            //}
            return mdtTable;
        }

        ///// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        ///// PARAMETER : MYSQL COMMAND
        ///// RETURN : DATATABLE
        //public DataTable ExecuteDataTablePaging(SqlCommand cmd, int iPageSize, int iPageNum)
        //{

        //    //SqlConnection conn = new SqlConnection(connectionString);
        //    //SqlCommand comm = new SqlCommand("select * from mytable", conn);
        //    //comm.Connection.Open();
        //    //SqlDataReader r =
        //    //    comm.ExecuteReader(CommandBehavior.CloseConnection);
        //    //while (r.Read())
        //    //{
        //    //    Console.WriteLine(r.GetString(0));
        //    //}
        //    //r.Close();
        //    //conn.Close();
            

        //    msQuery = cmd.CommandText;
        //    mdsDataSet = new DataSet();
        //    mdtTable = new DataTable();
        //    if (msQuery != "" || msQuery != string.Empty || msQuery != null)
        //    {
        //        try
        //        {
        //            OpenDataBase();
        //            cmd.Connection = mobjSqlConection;
        //            SqlDataReader objDR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //            mdtTable = objDR.GetSchemaTable();
        //            System.Console.Write ( objDR.RecordsAffected);
        //            //while (objDR.Read())
        //            //{
        //            //    mdtTable.ImportRow(objDR
        //            //    Response.Write(reader["field"]); // or reader[0] - int or string lookup
        //            //}
        //            objDR.Close();


        //            mobjSqlAdapter.SelectCommand = cmd;
        //            mobjSqlAdapter.Fill(mdsDataSet, cmd.CommandText);
        //            if (mdsDataSet != null && mdsDataSet.Tables.Count > 0)
        //                mdtTable = mdsDataSet.Tables[0];
        //            return mdtTable;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //            throw;
        //            return null;
        //        }
        //        finally
        //        {
        //            CloseDataBase();
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// SUMMARY : PROCEDURE
        /// PARAMETER : QUERY STRING, COMMAND PARAMS LIST
        /// RETURN : DATATABLE
        //public void ExecuteStoredProcedure(string strQuery, DataAccess.SqlParamData[] objParams)
        //{
        //    mobjSqlCommand = new SqlCommand(strQuery);
        //    mobjSqlCommand.CommandType = CommandType.StoredProcedure;
        //    mobjSqlCommand.CommandTimeout = 5000;
        //    foreach (DataAccess.SqlParamData objParam in objParams)
        //    {
        //        if (objParam.Direction == ParameterDirection.Output)
        //            mobjSqlCommand.Parameters.Add(objParam.Name, objParam.DataType, objParam.Length).Direction = objParam.Direction;
        //        else
        //            mobjSqlCommand.Parameters.Add(objParam.Name, objParam.DataType).Value = objParam.Value;
        //    }
        //    this.ExecuteNonQuery(mobjSqlCommand);
        //    for (int i = 0; i < objParams.Length; i++)
        //    {
        //        if (objParams[i].Direction == ParameterDirection.Output)
        //            objParams[i].Value = mobjSqlCommand.Parameters[objParams[i].Name].Value;
            
        //    }
        //}

        //public void ExecuteStoredProcedure(string strQuery, DataAccess.MySqlParamData[] objParams)
        //{
        //    mobjMySqlCommand = new MySqlCommand(strQuery);
        //    mobjMySqlCommand.CommandType = CommandType.StoredProcedure;
        //    foreach (DataAccess.MySqlParamData objParam in objParams)
        //    {
        //        if (objParam.Direction == ParameterDirection.Output)
        //            mobjMySqlCommand.Parameters.Add(objParam.Name, objParam.DataType, objParam.Length).Direction = objParam.Direction;
        //        else
        //            mobjMySqlCommand.Parameters.Add(objParam.Name, objParam.DataType).Value = objParam.Value;
        //    }
        //    this.ExecuteNonQuery(mobjMySqlCommand);
        //    for (int i = 0; i < objParams.Length; i++)
        //    {
        //        if (objParams[i].Direction == ParameterDirection.Output)
        //            objParams[i].Value = mobjMySqlCommand.Parameters[objParams[i].Name].Value;

        //    }
        //}

        ///// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        ///// PARAMETER : QUERY STRING, COMMAND PARAMS LIST
        ///// RETURN : DATATABLE
        //public DataTable ExecuteDataTablePaging(string strQuery, Dictionary<string, object> dicObjParams, int iPageSize, int iPageNum, out long iTotalRec)
        //{
        //    mdtTable = new DataTable();
        //    iTotalRec = 0;
        //    if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
        //    {
        //        mobjSqlCommand = new SqlCommand(strQuery);
        //        foreach (KeyValuePair<string, object> pair in dicObjParams)
        //        {
        //            mobjSqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
        //        }
        //        mdtTable = this.ExecuteDataTable(mobjSqlCommand, iPageSize,iPageNum, out iTotalRec);
        //    }
        //    else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
        //    {
        //        mobjMySqlCommand = new MySqlCommand(strQuery);
        //        foreach (KeyValuePair<string, object> pair in dicObjParams)
        //        {
        //            mobjMySqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
        //        }
        //        mdtTable = this.ExecuteDataTable(mobjMySqlCommand);
        //    }
        //    return mdtTable;
        //}
        
        ///// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        ///// PARAMETER : QUERY STRING, COMMAND PARAMS LIST
        ///// RETURN : DATATABLE
        ////public DataTable ExecuteDataTablePaging(string strProc, string strColumnIN, string strColumnOut, string strTable, string strWhere, string strOrderByIn, string strOrderByOut, int iPageSize, int iPageNum, out long iTotalRec)
        //public DataTable ExecuteDataTablePaging(string strProc, string strID, string strColumns, string strTable, string strWhere, string strOrderBy, int iPageSize, int iPageNum, out long iTotalRec)
        //{
        //    iTotalRec = 0;
        //    mdtTable = new DataTable();
        //    if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
        //    {
        //        mobjSqlCommand = new SqlCommand(strProc);
        //        mobjSqlCommand.CommandType = CommandType.StoredProcedure;
        //        //mobjSqlCommand.Parameters.Add("@currentPage", SqlDbType.Int).Value = iPageNum;
        //        //mobjSqlCommand.Parameters.Add("@pageSize", SqlDbType.Int).Value =iPageSize;
        //        //mobjSqlCommand.Parameters.Add("@SQLCOLUMNSOUT", SqlDbType.VarChar).Value =strColumnOut;
        //        //mobjSqlCommand.Parameters.Add("@SQLCOLUMNSIN", SqlDbType.VarChar).Value =strColumnIN;
        //        //mobjSqlCommand.Parameters.Add("@SQLTABLES", SqlDbType.VarChar).Value =strTable;
        //        //mobjSqlCommand.Parameters.Add("@SQLWHERE", SqlDbType.VarChar).Value =strWhere;
        //        //mobjSqlCommand.Parameters.Add("@SQLORDERBYOUT", SqlDbType.VarChar).Value =strOrderByOut;
        //        //mobjSqlCommand.Parameters.Add("@SQLORDERBYIN", SqlDbType.VarChar).Value =strOrderByIn;
        //        //mobjSqlCommand.Parameters.Add("@totalRec", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        //        mobjSqlCommand.Parameters.Add("@currentPage", SqlDbType.Int).Value = iPageNum;
        //        mobjSqlCommand.Parameters.Add("@pageSize", SqlDbType.Int).Value = iPageSize;
        //        mobjSqlCommand.Parameters.Add("@QRYID", SqlDbType.VarChar).Value = strID;
        //        mobjSqlCommand.Parameters.Add("@SQLCOLUMNS", SqlDbType.VarChar).Value = strColumns;
        //        mobjSqlCommand.Parameters.Add("@SQLTABLES", SqlDbType.VarChar).Value = strTable;
        //        mobjSqlCommand.Parameters.Add("@SQLWHERE", SqlDbType.VarChar).Value = strWhere;
        //        mobjSqlCommand.Parameters.Add("@SQLORDERBY", SqlDbType.VarChar).Value = strOrderBy;
        //        mobjSqlCommand.Parameters.Add("@totalRec", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        //        //CREATE PROCEDURE UserPaging
        //        //(
        //        //  @currentPage int = 1, @pageSize int =10,  @SQLCOLUMNSOUT varchar(1000), @SQLCOLUMNSIN varchar(1500), 
        //        //  @SQLTABLES varchar(1000), @SQLWHERE varchar(1000), @SQLORDERBYOUT varchar(500), @SQLORDERBYIN varchar(500), @totalRec int output
        //        //)

        //        //SqlCommand Cmd = new SqlCommand("dbo.UserPaging", cn);
        //        //Cmd.CommandType = CommandType.StoredProcedure;
        //        //SqlDataReader dr;
        //        //Cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = pager1.PageSize;
        //        //Cmd.Parameters.Add("@CurrentPage", SqlDbType.Int, 4).Value = pager1.CurrentIndex;
        //        //Cmd.Parameters.Add("@ItemCount", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        //cn.Open();
        //        //dr = Cmd.ExecuteReader();
        //        //rptProducts.DataSource = dr;
        //        //rptProducts.DataBind();
        //        //dr.Close();
        //        //cn.Close();
        //        //Int32 _totalRecords = Convert.ToInt32(Cmd.Parameters["@ItemCount"].Value);
        //        //pager1.ItemCount = _totalRecords;

        //        mdtTable = this.ExecuteDataTable(mobjSqlCommand);
        //        iTotalRec = Convert.ToInt64(mobjSqlCommand.Parameters["@totalRec"].Value);
        //    }
        //    else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
        //    {
        //        mobjMySqlCommand = new MySqlCommand(strProc);
        //        mobjMySqlCommand.CommandType = CommandType.StoredProcedure;
        //        //mobjMySqlCommand.Parameters.Add("@currentPage",MySqlDbType.Int32).Value = iPageNum;
        //        //mobjMySqlCommand.Parameters.Add("@pageSize", MySqlDbType.Int32).Value = iPageSize;
        //        //mobjMySqlCommand.Parameters.Add("@SQLCOLUMNSOUT", MySqlDbType.VarChar).Value = strColumnOut;
        //        //mobjMySqlCommand.Parameters.Add("@SQLCOLUMNSIN", MySqlDbType.VarChar).Value = strColumnIN;
        //        //mobjMySqlCommand.Parameters.Add("@SQLTABLES", MySqlDbType.VarChar).Value = strTable;
        //        //mobjMySqlCommand.Parameters.Add("@SQLWHERE", MySqlDbType.VarChar).Value = strWhere;
        //        //mobjMySqlCommand.Parameters.Add("@SQLORDERBYOUT", MySqlDbType.VarChar).Value = strOrderByOut;
        //        //mobjMySqlCommand.Parameters.Add("@SQLORDERBYIN", MySqlDbType.VarChar).Value = strOrderByIn;
        //        //mobjMySqlCommand.Parameters.Add("@totalRec", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //        mobjMySqlCommand.Parameters.Add("@currentPage", MySqlDbType.Int32).Value = iPageNum;
        //        mobjMySqlCommand.Parameters.Add("@pageSize", MySqlDbType.Int32).Value = iPageSize;
        //        mobjMySqlCommand.Parameters.Add("@QRYID", MySqlDbType.VarChar).Value = strID;
        //        mobjMySqlCommand.Parameters.Add("@SQLCOLUMNS", MySqlDbType.VarChar).Value = strColumns;
        //        mobjMySqlCommand.Parameters.Add("@SQLTABLES", MySqlDbType.VarChar).Value = strTable;
        //        mobjMySqlCommand.Parameters.Add("@SQLWHERE", MySqlDbType.VarChar).Value = strWhere;
        //        mobjMySqlCommand.Parameters.Add("@SQLORDERBY", MySqlDbType.VarChar).Value = strOrderBy;
        //        mobjMySqlCommand.Parameters.Add("@totalRec", MySqlDbType.Int32).Direction = ParameterDirection.Output;
        //        mdtTable = this.ExecuteDataTable(mobjMySqlCommand);
        //        iTotalRec = Convert.ToInt32(mobjMySqlCommand.Parameters["@totalRec"].Value);
        //        Console.WriteLine(iTotalRec);
        //    }
        //    return mdtTable;
        //}


        /// SUMMARY : EXECUTE QUERY AND RETURN DATATABLE
        /// PARAMETER : QUERY STRING
        /// RETURN : DATASET
        public DataSet ExecuteDataSet(string rQry)
        {
            msQuery = rQry;
            mdsDataSet = new DataSet();
            mdtTable = new DataTable();
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {

                try
                {
                    OpenDataBase();
                    if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                    {
                        mobjSqlCommand.CommandType = CommandType.Text;
                        mobjSqlCommand.CommandText = msQuery;
                        mobjSqlAdapter.SelectCommand = mobjSqlCommand;
                        mobjSqlAdapter.Fill(mdsDataSet, mobjSqlCommand.CommandText);
                    }
                    //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
                    //{
                    //    mobjMySqlCommand.CommandType = CommandType.Text;
                    //    mobjMySqlCommand.CommandText = msQuery;
                    //    mobjMySqlAdapter.SelectCommand = mobjMySqlCommand;
                    //    mobjMySqlAdapter.Fill(mdsDataSet, mobjMySqlCommand.CommandText);
                    //}
                    return mdsDataSet;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return null;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return null;
            }
        }

        /// SUMMARY : EXECUTE COMMAND AND RETURN DATASET
        /// PARAMETER : SQL COMMAND
        /// RETURN : DATASET
        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            msQuery = cmd.CommandText;
            mdsDataSet = new DataSet();
            //mdtTable = new DataTable();
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    cmd.Connection = mobjSqlConection;
                    mobjSqlAdapter.SelectCommand = cmd;
                    mobjSqlAdapter.Fill(mdsDataSet, cmd.CommandText);
                    mobjSqlAdapter.Dispose();
                    return mdsDataSet;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return null;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return null;
            }
        }

        /// SUMMARY : EXECUTE COMMAND AND RETURN DATASET
        /// PARAMETER : MYSQL COMMAND
        /// RETURN : DATASET

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN dataset
        /// PARAMETER : QUERY, COMMAND PARAMS LIST
        /// RETURN : dataset
        public DataSet ExecuteDataSet(String strQuery, Dictionary<string, object> dicObjParams)
        {
            DataSet ds = null;
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    mobjSqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                ds = this.ExecuteDataSet(mobjSqlCommand);
            }
            return ds;
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : QUERY STRING
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public long ExecuteNonQuery(string rQry)
        {
            long iRecordEffected = 0;
            msQuery = rQry;
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                    {
                        //MySqlTransaction mobjTransaction = cnn.BeginTransaction();
                        //mobjSqlCommand.Transaction = mobjTransaction;
                        //mobjTransaction.Commit();
                        //mobjTransaction.Rollback();
                        mobjSqlCommand.CommandType = CommandType.Text;
                        //ayaz added for query execution time                  
                        mobjSqlCommand.CommandTimeout = 0;// 0 = give it as much time as it needs to complete

                        mobjSqlCommand.CommandText = msQuery;
                        iRecordEffected = mobjSqlCommand.ExecuteNonQuery();
                    }
                    return iRecordEffected;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return 0;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return 0;
            }
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : COMMAND
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public long ExecuteNonQuery(SqlCommand cmd)
        {
            long iRecordEffected = 0;
            msQuery = cmd.CommandText;
            if (msQuery != "" || msQuery != string.Empty || msQuery != null)
            {
                try
                {
                    OpenDataBase();
                    cmd.Connection = mobjSqlConection;
                    iRecordEffected = cmd.ExecuteNonQuery();
                    return iRecordEffected;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return 0;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return 0;
            }
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : MYSQL COMMAND
        /// RETURN : NUMBER OF RECORDS EFFECTED

        /// SUMMARY : EXECUTE TRANSACTIONAL BATCH QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : QUERY STRING
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public long ExecuteBatchNonQuery(string[] rQrys)
        {
            long iRecordEffected = 0;
            //msQuery = rQry;
            if (rQrys != null && rQrys.Length > 0)
            {
                try
                {
                    OpenDataBase();
                    for (int i = 0; i < rQrys.Length; i++)
                    {
                        if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                        {
                            //MySqlTransaction mobjTransaction = cnn.BeginTransaction();
                            //mobjSqlCommand.Transaction = mobjTransaction;
                            //mobjTransaction.Commit();
                            //mobjTransaction.Rollback();
                            mobjSqlCommand.CommandType = CommandType.Text;
                            mobjSqlCommand.CommandText = rQrys[i];
                            iRecordEffected = mobjSqlCommand.ExecuteNonQuery();
                        }
                    }
                    return iRecordEffected;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return iRecordEffected;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return iRecordEffected;
            }
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL BATCH QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : COMMAND
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public long ExecuteBatchNonQuery(SqlCommand[] cmd)
        {
            long iRecordEffected = 0;
            //msQuery = cmd.CommandText;
            if (cmd != null && cmd.Length > 0)
            {
                try
                {
                    OpenDataBase();
                    for (int i = 0; i < cmd.Length; i++)
                    {
                        if (cmd[i].CommandText.Length > 0)
                        {
                            cmd[i].Connection = mobjSqlConection;
                            iRecordEffected = iRecordEffected + cmd[i].ExecuteNonQuery();
                        }
                    }
                    return iRecordEffected;
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                    return iRecordEffected;
                }
                finally
                {
                    //CloseDataBase();
                }
            }
            else
            {
                return iRecordEffected;
            }
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL BATCH QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : MYSQL COMMAND
        /// RETURN : NUMBER OF RECORDS EFFECTED

        public long ExecuteBatchNonQuery(object[] objParam)
        {
            long iRecordEffected = 0;
            if (objParam.GetType() != null && objParam.Length > 0)
            {
                if (objParam[0].GetType().FullName.Equals("System.Data.SqlClient.SqlCommand"))
                {
                    SqlCommand[] objSqlCmd = new SqlCommand[objParam.Length];
                    Array.Copy(objParam, objSqlCmd, objParam.Length);
                    iRecordEffected = ExecuteBatchNonQuery(objSqlCmd);
                }
                //if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
                //    iRecordEffected = ExecuteBatchNonQuery((SqlCommand[])objParam);
                //else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
                //    iRecordEffected = ExecuteBatchNonQuery((MySqlCommand[])objParam);
                //iRecordEffected = ExecuteBatchNonQuery();
            }
            return iRecordEffected;
        }

        /// SUMMARY : CONVERT QUERY TO COMAND OBJECT
        /// PARAMETER : QUERY, COMMAND PARAMS LIST
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public object ToCommandObject(String strQuery, Dictionary<string, object> dicObjParams)
        {
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    mobjSqlCommand.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                return mobjSqlCommand;
            }
            return null;
        }

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN NUMBER OF RECORDS EFFECTED
        /// PARAMETER : QUERY, COMMAND PARAMS LIST
        /// RETURN : NUMBER OF RECORDS EFFECTED
        public long ExecuteNonQuery(String strQuery, Dictionary<string, object> dicObjParams)
        {
            long iRecordEffected = 0;
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    try
                    {
                        mobjSqlCommand.Parameters.AddWithValue(pair.Key, IsDBNull(pair.Value));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(pair.ToString());
                    }
                }
                iRecordEffected = this.ExecuteNonQuery(mobjSqlCommand);
            }
            return iRecordEffected;
        }

        ///// SUMMARY : EXECUTE INSERT QUERY AND RETURN PRIMARY KEY
        ///// PARAMETER : QUERY STRING
        ///// RETURN : PRIMARY KEY
        //public long ExecuteNonQueryReturnID(string rQry)
        //{
        //    long iRecordEffected = 0;
        //    msQuery = rQry;
        //    if (msQuery != "" || msQuery != string.Empty || msQuery != null)
        //    {
        //        try
        //        {
        //            OpenDataBase();
        //            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
        //            {
        //                mobjSqlCommand.CommandType = CommandType.Text;
        //                mobjSqlCommand.CommandText = msQuery;
        //                iRecordEffected = Convert.ToInt64(mobjSqlCommand.ExecuteScalar());
        //            }
        //            else if (msConnectionType.Equals(enumConnectionType.MYSQL.ToString()))
        //            {
        //                mobjMySqlCommand.CommandType = CommandType.Text;
        //                mobjMySqlCommand.CommandText = msQuery;
        //                iRecordEffected = Convert.ToInt64(mobjMySqlCommand.ExecuteScalar());
        //            }
        //            return iRecordEffected;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //            throw;
        //            return 0;
        //        }
        //        finally
        //        {
        //            CloseDataBase();
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        ///// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN PRIMARY KEY
        ///// PARAMETER : COMMAND
        ///// RETURN : PRIMARY KEY
        //public long ExecuteNonQueryReturnID(SqlCommand cmd)
        //{
        //    long iRecordEffected = 0;
        //    msQuery = cmd.CommandText;
        //    if (msQuery != "" || msQuery != string.Empty || msQuery != null)
        //    {
        //        try
        //        {
        //            OpenDataBase();
        //            //mobjSqlCommand.CommandType = cmd.CommandType;
        //            //mobjSqlCommand.CommandText = cmd.CommandText;
        //            cmd.Connection = mobjSqlConection;
        //            iRecordEffected = Convert.ToInt64(cmd.ExecuteScalar());
        //            return iRecordEffected;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //            throw;
        //            return 0;
        //        }
        //        finally
        //        {
        //            CloseDataBase();
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        ///// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN PRIMARY KEY
        ///// PARAMETER : MYSQL COMMAND
        ///// RETURN : PRIMARY KEY
        //public long ExecuteNonQueryReturnID(MySqlCommand cmd)
        //{
        //    long iRecordEffected = 0;
        //    msQuery = cmd.CommandText;
        //    if (msQuery != "" || msQuery != string.Empty || msQuery != null)
        //    {
        //        try
        //        {
        //            OpenDataBase();
        //            cmd.Connection = mobjMySqlConection;
        //            iRecordEffected = Convert.ToInt64(cmd.ExecuteScalar());
        //            return iRecordEffected;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //            throw;
        //            return 0;
        //        }
        //        finally
        //        {
        //            CloseDataBase();
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        /// SUMMARY : EXECUTE TRANSACTIONAL QUERY AND RETURN PRIMARY KEY
        /// PARAMETER : QUERY STRING, PARAMS
        /// RETURN : PRIMARY KEY
        public long ExecuteNonQueryReturnID(String strQuery, Dictionary<string, object> dicObjParams, String strTable, String strColumn)
        {
            long iRecordEffected = 0;
            string strRecRndKey = "";
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    mobjSqlCommand.Parameters.AddWithValue(pair.Key, IsDBNull(pair.Value));
                    if (pair.Key.ToLower().Equals("@rec_rnd_key"))
                        strRecRndKey = pair.Value.ToString();
                }
                //iRecordEffected = this.ExecuteNonQueryReturnID(mobjSqlCommand);
                iRecordEffected = this.ExecuteNonQuery(mobjSqlCommand);
            }
            if (iRecordEffected > 0)
            {
                string strQry = "SELECT MAX(" + strColumn + ") as PKID FROM " + strTable + " WHERE rec_rnd_key='" + strRecRndKey + "'";
                DataTable dtTmp = this.ExecuteDataTable(strQry);
                if (dtTmp.Rows.Count > 0)
                    iRecordEffected = Convert.ToInt64(dtTmp.Rows[0][0].ToString());
            }
            return iRecordEffected;
        }

        public long ExecuteNonQueryReturnIDFHM(String strQuery, Dictionary<string, object> dicObjParams, String strTable, String strColumn)
        {
            long iRecordEffected = 0;
            string strRecRndKey = "";
            if (msConnectionType.Equals(enumConnectionType.MSSQL.ToString()))
            {
               
                mobjSqlCommand = new SqlCommand(strQuery);
                foreach (KeyValuePair<string, object> pair in dicObjParams)
                {
                    mobjSqlCommand.Parameters.AddWithValue(pair.Key, IsDBNull(pair.Value));
                }
                iRecordEffected = this.ExecuteNonQuery(mobjSqlCommand);
                //iRecordEffected = Convert.ToInt64(mobjSqlCommand.ExecuteScalar());
        
            }
            if (iRecordEffected > 0)
            {
                string strQry = "SELECT MAX(" + strColumn + ") as PKID FROM " + strTable + " ";
                DataTable dtTmp = this.ExecuteDataTable(strQry);
                if (dtTmp.Rows.Count > 0)
                    iRecordEffected = Convert.ToInt64(dtTmp.Rows[0][0].ToString());
            }
            return iRecordEffected;
        }

     

        #endregion

        public static object IsDBNull(Object objVar)
        {
            if (objVar.GetType() == typeof(String))
            {
                if (objVar.ToString().Equals(String.Empty) || objVar.ToString().Equals(null))
                    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(Int32))
            {
                if (Convert.ToInt32(objVar) == Int32.MinValue)
                    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(Int64))
            {
                if (Convert.ToInt64(objVar) == Int64.MinValue)
                    return DBNull.Value;
                //else if (Convert.ToInt32(objVar) == Int32.MinValue)
                //    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(long))
            {
                if (Convert.ToInt64(objVar) == long.MinValue)
                    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(decimal))
            {
                if (Convert.ToDecimal(objVar) == decimal.MinValue)
                    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(DateTime))
            {
                if (Convert.ToDateTime(objVar) == DateTime.MinValue)
                    return DBNull.Value;
                else
                    return objVar;
            }
            else if (objVar.GetType() == typeof(Boolean))
            {
                return objVar;
            }
            return DBNull.Value;
        }
    }
}
