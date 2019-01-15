using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DNLiCore_DB
{
    public class SqlLiteHelper:ISqlLiteHelper
    {

        private static string connString;

        // connString = "Data Source=ItcastCater.db";
        public SqlLiteHelper(string myConnString)
        {
            connString = myConnString;
        }

        /// <summary>
        /// 执行sql语句返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            int resultInt = 0;
            using (SqliteConnection conn = new SqliteConnection(connString))
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand(sql, conn);
                resultInt = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return resultInt;
        }


        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Query(string sql)
        {
            using (SqliteConnection connection = new SqliteConnection(connString))
            {
                connection.Open();
                SqliteCommand cmd = new SqliteCommand(sql, connection);
                using (SqliteDataReader da = cmd.ExecuteReader())
                {

                    DataTable dataTable = new DataTable();                    
                    try
                    {
                        //创建列
                        for (int i = 0; i < da.FieldCount; i++)
                        {
                            Type columType = da.GetFieldType(i);
                            string columName = da.GetName(i);
                            dataTable.Columns.Add(columName, columType);
                        }
                        //创建行

                        while (da.Read())
                        {
                            DataRow dataRow = dataTable.NewRow();
                            for (int i = 0; i < da.FieldCount; i++)
                            {
                                dataRow[i] = da.GetValue(i);
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                        cmd.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        // throw new Exception(ex.Message);
                        connection.Close();
                        //DAL.Common.FileTxtLogs.WriteLog(ex.Message);
                    }
                    return dataTable;
                }
            }
        }


    }
}
