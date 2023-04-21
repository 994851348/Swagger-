using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace LocalHostTest.Dapper
{
    /// <summary>
    /// MySQL处理底层封装
    /// </summary>
    public class MySQLHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;//连接的字符串
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
        /// <summary>
        /// 执行sql并返回List泛型
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="files">查询字段</param>
        /// <param name="tableName">表名</param>
        /// <param name="where">条件</param>
        /// <param name="_object">object</param>
        /// <returns></returns>
        public static List<T> QueryToList<T>(string files, string tableName, string where, object _object)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT {0} FROM {1} where {2};", files, tableName, where);
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                List<T> data = connection.Query<T>(sb.ToString(), _object).ToList<T>();
                return data;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// 执行sql并且返回实体类型
        /// </summary>
        /// <param name="files">字段</param>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <param name="_object"></param>
        /// <returns></returns>
        public static T QueryToModel<T>(string files, string tableName, string where, object _object)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT {0} FROM {1} where {2};", files, tableName, where);
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                T data = connection.Query<T>(sb.ToString(), _object).SingleOrDefault<T>();
                return data;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// 新增实体表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long Insert<T>(object obj) where T : class, new()
        {

            long id = 1;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                id = connection.Insert<T>((T)obj);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
        /// <summary>
        /// 修改实体表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Update<T>(object obj) where T : class, new()
        {

            bool result = false;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                result = connection.Update<T>((T)obj);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Delete<T>(object obj) where T : class, new()
        {

            bool result = false;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                result = connection.Delete<T>((T)obj);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string sql)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sql.ToString());
                return IDataReaderToDataTable(idr);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="_object">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTableByParamsSql(string sql, object _object)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sql.ToString(), _object);
                return IDataReaderToDataTable(idr);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="_object">参数</param>
        /// <returns></returns>
        public static int UpdateByParamsSql(string sql, object _object)
        {

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                int i = conn.Execute(sql.ToString(), _object);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="files">字段</param>
        /// <param name="tableName">表</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string files, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT {0} FROM {1};", files, tableName);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sb.ToString());
                return IDataReaderToDataTable(idr);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="files">字段</param>
        /// <param name="tableName">表</param>
        /// <param name="where">条件</param>
        /// <param name="_object">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTableByParams(string files, string tableName, string where, object _object)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT {0} FROM {1} where {2};", files, tableName, where);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sb.ToString(), _object);
                return IDataReaderToDataTable(idr);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取sql
        /// </summary>
        /// <param name="files">列</param>
        /// <param name="tableName">表</param>
        /// <param name="where">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">当前页显示条数</param>
        /// <param name="_object">参数</param>
        /// <returns></returns>
        public static DataTable GetPageList(string files, string tableName, string where, string orderby, int pageIndex, int pageSize, object _object)
        {
            int skip = 1;
            if (pageIndex > 0)
            {
                skip = (pageIndex - 1) * pageSize + 1;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT  {0}
                                FROM(SELECT ROW_NUMBER() OVER(ORDER BY {3}) AS RowNum,{0}
                                          FROM  {1}
                                          WHERE {2}
                                        ) AS result
                                WHERE  RowNum >= {4}   AND RowNum <= {5}
                                ORDER BY {3}", files, tableName, where, orderby, skip, pageIndex * pageSize);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sb.ToString(), _object);
                return IDataReaderToDataTable(idr);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="files">字段</param>
        /// <param name="tableName">表</param>
        /// <param name="where">条件</param>
        /// <param name="_object">参数</param>
        /// <returns></returns>
        public static int GetPageListCount(string files, string tableName, string where, object _object)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT {0} FROM {1} where {2};", files, tableName, where);
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                IDataReader idr = conn.ExecuteReader(sb.ToString(), _object);
                return IDataReaderToDataTable(idr).Rows.Count;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 把idatareader转换成datatable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static DataTable IDataReaderToDataTable(IDataReader reader)
        {

            DataTable objDataTable = new DataTable();
            int intFieldCount = reader.FieldCount;
            for (int intCounter = 0; intCounter < intFieldCount; ++intCounter)
            {
                objDataTable.Columns.Add(reader.GetName(intCounter).ToLower(), typeof(string));
            }
            objDataTable.BeginLoadData();
            object[] objValues = new object[intFieldCount];
            while (reader.Read())
            {
                reader.GetValues(objValues);
                objDataTable.LoadDataRow(objValues, true);

            }
            reader.Close();
            objDataTable.EndLoadData();
            return objDataTable;
        }
    }
}