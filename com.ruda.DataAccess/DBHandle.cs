using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace com.ruda.DataAccess
{
    public class DBHandle
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader = null;
        private SqlDataAdapter adapter;
        private DataTable table;
        private DataSet set;

        #region DB connectivity

        public DBHandle()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                CloseConnection();
            }
            else
            {
                CreateConnection();
            }
        }

        private void CreateConnection()
        {
            try
            {
                //string conString = "Server=172.16.0.10;Database=NBV_RUDA;User id=sa;password=Ruda@2022;Trusted_Connection=False;";
                string conString = "Server=DD-IT;Database=NBV_RUDA;User id=sa;password=root;Trusted_Connection=False;";
                con = new SqlConnection(conString);
            }
            catch (Exception ex) { throw new Exception("Error Generating Connection String \n Message: " + ex.Message); }
        }

        public void OpenConnection()
        {
            if (con == null)
            {
                CreateConnection();
                OpenConnection();
            }
            else if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            else
            {
                CloseConnection();
                con.Open();
            }
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public SqlConnection GetConnection()
        { return con; }

        #endregion

        #region Get Data Functions

        public string ExecuteReader(string str)
        {
            OpenConnection();
            cmd = new SqlCommand(str, con);
            reader = cmd.ExecuteReader();
            string Value = "";
            while (reader.Read())
            {
                Value = reader[0].ToString();
            }
            reader.Close();
            CloseConnection();
            return Value;
        }

        public DataSet FillDS(string Query, string TableName)
        {
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(Query, con);
            DataSet tempDs = new DataSet();
            adapter.Fill(tempDs, TableName);
            if (tempDs.Tables.Count > 0)
            {
                return tempDs;
            }
            else
                return null;
        }

        public void ExecuteQuery(string Query)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ExecuteQuery(string Query, SqlConnection cn, SqlTransaction transaction)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();
                cmd = new SqlCommand(Query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public object ExecuteQuery_1(string Query)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            object temp = cmd.ExecuteScalar();
            return temp;
        }

        public object ExecuteQuery_1(string Query, SqlConnection cn, SqlTransaction transaction)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            object temp = cmd.ExecuteScalar();
            return temp;
        }

        public void ExecuteParatemerizedSQLCommand(string query, params object[] parameters)
        {
            try
            {
                OpenConnection();
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }

                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }

                OpenConnection();
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public void ExecuteParatemerizedSQLCommand(string query, SqlConnection cn, SqlTransaction transaction, params object[] parameters)
        {
            try
            {
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }

                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }

                SqlConnection innerConnection = cn;

                if (innerConnection.State == ConnectionState.Closed)
                    innerConnection.Open();

                query = query.Replace("@", ":");
                cmd = new SqlCommand(query, innerConnection);
                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public void ExecuteSP(string query, params object[] parameters)
        {
            try
            {
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');

                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }
                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }

                OpenConnection();

                string[] _procName = atemp[0].Split(',');

                cmd = new SqlCommand(_procName[0], con);
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }

                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public void ExecuteSP(string query, SqlConnection cn, SqlTransaction trans, params object[] parameters)
        {
            try
            {
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }
                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }
                SqlConnection innerConnection = cn;

                if (innerConnection.State == ConnectionState.Closed)
                    innerConnection.Open();

                string[] _procName = atemp[0].Split(',');
                cmd = new SqlCommand(_procName[0], innerConnection);
                cmd.Transaction = trans;

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { }
        }

        public DataTable GetDataTable(string Query)
        {
            try
            {
                OpenConnection();
                table = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = Query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public DataTable GetDataTable(string Query, SqlConnection con, SqlTransaction transaction)
        {
            try
            {
                SqlConnection innerConnection = con;
                if (innerConnection.State == ConnectionState.Closed) innerConnection.Open();
                SqlCommand innerCommand = new SqlCommand(Query, innerConnection);
                innerCommand.CommandType = CommandType.Text;
                innerCommand.Transaction = transaction;
                table = new DataTable();
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = innerCommand;
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { }
        }

        public DataTable FillDTSP(string query, params object[] parameters)
        {
            try
            {
                table = new DataTable();
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }
                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }
                OpenConnection();
                string[] _procName = atemp[0].Split(',');
                cmd = new SqlCommand(_procName[0], con);
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                CloseConnection();
                return table;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public DataSet FillDSSP(string query, params object[] parameters)
        {
            try
            {
                set = new DataSet();
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }
                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }
                OpenConnection();
                string[] _procName = atemp[0].Split(',');
                cmd = new SqlCommand(_procName[0], con);
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(set);
                CloseConnection();
                return set;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public Int64 ExecuteSPWithReturnID(string query, params object[] parameters)
        {
            try
            {
                string[] parameter = new string[query.Split('@').Length - 1];
                string[] atemp = query.Split('@');
                for (int i = 1; i < atemp.Length; i++)
                {
                    string[] stemp = atemp[i].Split(' ');
                    string[] ctemp = stemp[0].Split(',');
                    string[] cbtemp = ctemp[0].Split(')');
                    string[] obtemp = cbtemp[0].Split('(');
                    string[] sctemp = obtemp[0].Split(';');
                    parameter[i - 1] = "@" + sctemp[0];
                }
                if (parameters.Length != parameter.Length)
                {
                    throw new Exception("Wrong paramaters");
                }
                OpenConnection();
                string[] _procName = atemp[0].Split(',');
                cmd = new SqlCommand(_procName[0], con);
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter[i], parameters[i]));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                Int64 ID = Convert.ToInt64(cmd.ExecuteScalar());
                CloseConnection();
                return ID;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        #endregion
    }
}
