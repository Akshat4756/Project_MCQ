using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{

    public class DataAccessMethod
    {
        #region Methods
        #region Global Variables
        private SqlConnection MyConn = null;
        private string StringConnection = null;

        #endregion
        //"server=ANAND;database=SMS;uid=sa;password=sa";
        //ConfigurationSettings.AppSettings["StrConn"].ToString();
        /// <summary>
        /// Method to open connection of database.
        /// </summary>
        private void OpenConnection()
        {
            if (MyConn == null)
            {
               StringConnection = ConfigurationSettings.AppSettings["ConnectionString"];
                MyConn = new SqlConnection(StringConnection);
            }
            if (MyConn.State == ConnectionState.Closed || MyConn.State == ConnectionState.Broken)
            {
                MyConn.Open();
            }
        }
        private SqlCommand CreateCmd(string procName, params object[] ps)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = MyConn;
            SqlParameter[] sqlpa = null;

            if (ps != null)
            {
                SqlCommandBuilder.DeriveParameters(cmd);
                cmd.Parameters.RemoveAt(0);
                sqlpa = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(sqlpa, 0);
                for (int i = 0; i < sqlpa.Length; ++i)
                {
                    sqlpa[i].Value = ps[i];
                }
            }
            return cmd;
        }



        public SqlCommand CreateTransCmd(string procName, SqlTransaction trans, params object[] ps)
        {
            SqlCommand cmd = new SqlCommand(procName, MyConn, trans);
            try
            {

                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = MyConn;
                SqlParameter[] sqlpa = null;

                if (ps != null)
                {
                    SqlCommandBuilder.DeriveParameters(cmd);
                    cmd.Parameters.RemoveAt(0);
                    sqlpa = new SqlParameter[cmd.Parameters.Count];
                    cmd.Parameters.CopyTo(sqlpa, 0);
                    for (int i = 0; i < sqlpa.Length; ++i)
                    {
                        sqlpa[i].Value = ps[i];
                    }
                }
                return cmd;
            }
            catch (Exception)
            {
                trans.Rollback();
                MyConn.Close();
                return cmd;
            }
        }
    #endregion

    public string ExecuteNonQueryWithOutPutParameter(string procName, params object[] ps)
    {
      string i = "";
      using (SqlCommand cmd = CreateCmd(procName, ps))
      {
        try
        {
          i = Convert.ToString(cmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
          return null;
        }
        return i;
      }
    }
    public DataTable SelectRecordByDatatable(string procName)
        {
            using (SqlCommand cmd = CreateCmd(procName, null))
            {
                using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();

                    //Load DataReader into the DataTable.
                    dt.Load(sdr);
                    return dt;
                }

            }

        }

        public DataTable SelectRecordByDatatable(string procName, params object[] ps)
        {
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();

                    //Load DataReader into the DataTable.
                    dt.Load(sdr);
                    return dt;
                }

            }

        }
        public DataSet SelectRecordByDataSet(string procName, params object[] ps)
        {
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                using (SqlDataAdapter sqlad = new SqlDataAdapter())
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            // ds.Clear();
                            sqlad.SelectCommand = cmd;
                            sqlad.Fill(ds);
                        }
                        catch
                        {
                            return new DataSet();
                        }
                        return ds;
                    }
                }
            }
        }
        public DataSet SelectRecordByDataSet(string procName)
        {
            using (SqlCommand cmd = CreateCmd(procName, null))
            {
                using (SqlDataAdapter sqlad = new SqlDataAdapter())
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            // ds.Clear();
                            sqlad.SelectCommand = cmd;
                            sqlad.Fill(ds);
                        }
                        catch
                        {
                            return new DataSet();
                        }
                        return ds;
                    }
                }
            }
        }

        public int InsertRecord(string procName, params object[] ps)
        {
            int i = 0;
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                return i;
            }
        }
        public int InsertRecordWithOutPutParameter(string procName, params object[] ps)
        {
            int i = 0;
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                try
                {
                    //i = cmd.ExecuteNonQuery();
                    i = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
                return i;
            }
        }

        public int UpdateRecord(string procName, params object[] ps)
        {
            int i = 0;
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    return 0;
                }
                return i;
            }
        }
        public int UpdateRecordWithOutPutParameter(string procName, params object[] ps)
        {
            int i = 0;
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                try
                {
                    //i = cmd.ExecuteNonQuery();
                    i = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
                return i;
            }
        }
        public int DeleteRecord(string procName, params object[] ps)
        {
            int i = 0;
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return 0;
                }
                return i;
            }
        }
        public SqlDataReader SelectRecordBydataReader(string procName)
        {
            using (SqlCommand cmd = CreateCmd(procName, null))
            {
                SqlDataReader sdr = null;
                return sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public SqlDataReader SelectRecordBydataReader(string procName, params object[] ps)
        {
            using (SqlCommand cmd = CreateCmd(procName, ps))
            {
                SqlDataReader sdr = null;
                return sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }



    }
}

