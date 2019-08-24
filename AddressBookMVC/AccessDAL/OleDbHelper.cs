using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace AccessDAL
{
    public class OleDbHelper
    {
        private static string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ConfigurationManager.AppSettings["DbPath"];

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return OleDbHelper.connString; }
            set { OleDbHelper.connString = value; }
        }

        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, OleDbParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string commandText, OleDbParameter[] parameters)
        {
            return ExecuteDataTable(commandText, CommandType.Text, parameters);
        }
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }
        #endregion

        #region ExecuteReader
        public static OleDbDataReader ExecuteReader(string commandText, CommandType commandType, OleDbParameter[] parameters)
        {
            OleDbConnection conn = new OleDbConnection(connString); // 这里不用 using 的原因是在函数作用域内还不可以关闭 Connection 连接，还要返回 reader 对象
            OleDbCommand cmd = new OleDbCommand(commandText, conn);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (OleDbParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);  // 参数指定关闭 reader 对象时关闭 Connection 对象
        }
        public static OleDbDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, CommandType.Text, null);
        }
        public static OleDbDataReader ExecuteReader(string commandText, OleDbParameter[] parameters)
        {
            return ExecuteReader(commandText, CommandType.Text, parameters);
        }
        public static OleDbDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }
        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(string commandText, CommandType commandType, OleDbParameter[] parameters)
        {
            object result = null;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }
        public static object ExecuteScalar(string commandText, OleDbParameter[] parameters)
        {
            return ExecuteScalar(commandText, CommandType.Text, parameters);
        }
        public static object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }
        #endregion

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string commandText, CommandType commandType, OleDbParameter[] parameters)
        {
            int count = 0;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    conn.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return count;
        }
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string commandText, OleDbParameter[] parameters)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }
        #endregion
    }
}
