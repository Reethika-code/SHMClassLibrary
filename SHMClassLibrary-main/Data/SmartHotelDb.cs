using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SHMClassLibrary
{
    internal class SmartHotelDb
    {
        static SqlConnection connection = new SqlConnection("Data Source=LTIN594013;Initial Catalog=table;Integrated Security=True;TrustServerCertificate=true");

        #region Connection Management

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        #endregion

        #region SQL Methods

        public int InsertUpdateOrDelete(string queryOrSPName, nameValuePairList parameters, bool isStoredProcedure = false)
        {
            SqlCommand command = new SqlCommand(queryOrSPName, GetConnection());
            if (isStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            foreach (nameValuePair param in parameters)
            {
                command.Parameters.Add(new SqlParameter(param.ColName, param.Value));
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public int InsertUpdateOrDelete(string InsertQuery)
        {
            SqlCommand cmdObject = new SqlCommand(InsertQuery, GetConnection());
            int status = 0;

            try
            {
                status = cmdObject.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    CloseConnection();
                }
                return status;
            }
            catch (Exception exp)
            {
                return status;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    CloseConnection();
                }
            }
        }

        public DataTable FillAndReturnDataTable(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }

        public DataTable FillAndReturnDataTable(string query, nameValuePairList parameters)
        {
            SqlCommand cmd = new SqlCommand(query, GetConnection());

            foreach (nameValuePair param in parameters)
            {
                cmd.Parameters.Add(new SqlParameter(param.ColName, param.Value));
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }

        public object FetchCount(string query)
        {
            SqlCommand command = new SqlCommand(query, GetConnection());
            object count = command.ExecuteScalar();
            CloseConnection();
            return count;
        }

        public DataTable FetchData(string query, nameValuePairList parameters = null)
        {
            SqlCommand cmd = new SqlCommand(query, GetConnection());

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(param.ColName, param.Value));
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }

        #endregion
    }

    #region NameValuePair Classes

    public class nameValuePairList : List<nameValuePair>
    {
    }

    public class nameValuePair
    {
        public string ColName { get; set; }
        public object Value { get; set; }
        public string Key { get; internal set; }

        public nameValuePair(string colName, object value)
        {
            ColName = colName;
            Value = value;
        }
    }

    #endregion
}