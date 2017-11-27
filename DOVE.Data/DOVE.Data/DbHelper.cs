using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DOVE.Data
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.10.10
    /// 描 述：数据库访问扩展
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DatabaseType DbType { get; set; }
        //---------------add by zy 20170913------------------------>>>>>
        public static string DataSource { get; set; }
        public static string PersistSecurityInfo { get; set; }
        public static string Pwd { get; set; }
        public static string UserID { get; set; }
        public static string InitialCatalog { get; set; }
        //---------------add by zy 20170913------------------------<<<<<
        #region 构造函数
        /// <summary>
        /// 构造方法
        /// </summary>
        public DbHelper(DbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            dbCommand = dbConnection.CreateCommand();
            //// add by zy 20170913 获取数据库配置的详细信息并缓存
            //string providerName = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDb"].ProviderName.ToString();
            //if (string.IsNullOrEmpty(providerName))
            //    return;
            //DatabaseTypeEnumParse(providerName);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private DbConnection dbConnection { get; set; }
        /// <summary>
        /// 执行命令对象
        /// </summary>
        private IDbCommand dbCommand { get; set; }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
            if (dbCommand != null)
            {
                dbCommand.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 执行SQL返回 DataReader
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType cmdType, string strSql)
        {
            return ExecuteReader(cmdType, strSql, null);
        }
        /// <summary>
        /// 执行SQL返回 DataReader
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="dbParameter">Sql参数</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType cmdType, string strSql, params DbParameter[] dbParameter)
        {
            try
            {
                PrepareCommand(dbConnection, dbCommand, null, cmdType, strSql, dbParameter);
                IDataReader rdr = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string strSql)
        {
            return ExecuteScalar(cmdType, strSql);
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="dbParameter">Sql参数</param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            try
            {
                PrepareCommand(dbConnection, dbCommand, null, cmdType, cmdText, parameters);
                object val = dbCommand.ExecuteScalar();
                dbCommand.Parameters.Clear();
                return val;
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }
        /// <summary>
        /// 为即将执行准备一个命令
        /// </summary>
        /// <param name="conn">SqlConnection对象</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="isOpenTrans">DbTransaction对象</param>
        /// <param name="cmdType">执行命令的类型（存储过程或T-SQL，等等）</param>
        /// <param name="cmdText">存储过程名称或者T-SQL命令行, e.g. Select * from Products</param>
        /// <param name="dbParameter">执行命令所需的sql语句对应参数</param>
        private void PrepareCommand(DbConnection conn, IDbCommand cmd, DbTransaction isOpenTrans, CommandType cmdType, string cmdText, params DbParameter[] dbParameter)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (isOpenTrans != null)
                cmd.Transaction = isOpenTrans;
            cmd.CommandType = cmdType;
            if (dbParameter != null)
            {
                dbParameter = DbParameters.ToDbParameter(dbParameter);
                foreach (var parameter in dbParameter)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 用于数据库类型的字符串枚举转换 add by zy 20170913
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public void DatabaseTypeEnumParse(string value)
        {
            try
            {
                switch (value)
                {
                    case "System.Data.SqlClient":
                        DbType = DatabaseType.SqlServer;
                        SqlConnectionStringBuilder sql_sb = new SqlConnectionStringBuilder(dbConnection.ConnectionString);
                        DataSource = sql_sb.DataSource;
                        PersistSecurityInfo = sql_sb.PersistSecurityInfo.ToString();
                        Pwd = sql_sb.Password;
                        UserID = sql_sb.UserID;
                        InitialCatalog = sql_sb.InitialCatalog;
                        break;
                    case "Oracle.ManagedDataAccess.Client":
                        DbType = DatabaseType.Oracle;
                        OracleConnectionStringBuilder ora_sb = new OracleConnectionStringBuilder(dbConnection.ConnectionString);
                        DataSource = ora_sb.DataSource;
                        PersistSecurityInfo = ora_sb.PersistSecurityInfo.ToString();
                        Pwd = ora_sb.Password;
                        UserID = ora_sb.UserID;
                        InitialCatalog = "";
                        break;
                    case "MySql.Data.MySqlClient":
                        DbType = DatabaseType.MySql;
                        break;
                    case "System.Data.OleDb":
                        DbType = DatabaseType.Access;
                        break;
                    case "System.Data.SQLite":
                        DbType = DatabaseType.SQLite;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw new Exception("数据库类型\"" + value + "\"错误，请检查！");
            }
        }
    }
}
