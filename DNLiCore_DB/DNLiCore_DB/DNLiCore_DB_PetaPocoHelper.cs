using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DNLiCore_DB
{
    public class PetaPocoHelper : IPetaPocoHelper
    {
        Database db;
        int resultInt;
        /// <summary>
        /// 0:MySql,1:SqlServer,2:SqlLite
        /// </summary>
        /// <param name="sqlType">0:MySql,1:SqlServer,2:SqlLite</param>
        /// <param name="myconnstr"></param>
        public PetaPocoHelper(string myconnstr, int sqlType = 0)
        {
            if (sqlType == 0)
            {
                MySqlConnection connection = new MySqlConnection(myconnstr);
                db = new Database(connection);

            }
            else if (sqlType == 1)
            {
                SqlConnection connection = new SqlConnection(myconnstr);
                db = new Database(connection);
            }
            else if (sqlType == 2)
            {
                SqliteConnection connection = new SqliteConnection(myconnstr);
                db = new Database(connection);
            }
            db.CommandTimeout = 60; //超时时间
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="poco">实体</param>
        /// <returns></returns>
        public int Delete(object poco)
        {
            resultInt = db.Delete(poco);

            return resultInt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Delete<T>(Sql sql)
        {
            resultInt = db.Delete<T>(sql);

            return resultInt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Delete<T>(string sql, params object[] args)
        {
            resultInt = db.Delete<T>(sql, args);

            return resultInt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        public int Delete(string tableName, string primaryKeyName, object poco, object primaryKeyValue)
        {
            resultInt = db.Delete(tableName, primaryKeyName, poco, primaryKeyValue);

            return resultInt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pocoOrPrimaryKey"></param>
        /// <returns></returns>
        public int Delete<T>(object pocoOrPrimaryKey)
        {
            resultInt = db.Delete<T>(pocoOrPrimaryKey);

            return resultInt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <returns></returns>
        public int Delete(string tableName, string primaryKeyName, object poco)
        {
            resultInt = db.Delete(tableName, primaryKeyName, poco);

            return resultInt;
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(Sql sql)
        {
            resultInt = db.Execute(sql);

            return resultInt;
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Execute(string sql, params object[] args)
        {
            resultInt = db.Execute(sql, args);

            return resultInt;
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(string sql, params object[] args)
        {
            T resultT = db.ExecuteScalar<T>(sql, args);

            return resultT;
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(Sql sql)
        {
            T resultT = db.ExecuteScalar<T>(sql);

            return resultT;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(int page, int itemsPerPage, string sql, params object[] args)
        {
            List<T> resultT = db.Fetch<T>(page, itemsPerPage, sql, args);

            return resultT;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(Sql sql)
        {
            List<T> resultT = db.Fetch<T>(sql);

            return resultT;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(int page, int itemsPerPage, Sql sql)
        {
            List<T> resultT = db.Fetch<T>(page, itemsPerPage, sql);

            return resultT;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(string sql, params object[] args)
        {
            List<T> resultT = db.Fetch<T>(sql, args);

            return resultT;
        }
        /// <summary>
        /// 获取第一条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T First<T>(Sql sql)
        {
            T resultT = db.First<T>(sql);

            return resultT;
        }
        /// <summary>
        /// 获取第一条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T First<T>(string sql, params object[] args)
        {
            T resultT = db.First<T>(sql, args);

            return resultT;
        }
        /// <summary>
        /// 获取第一条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(Sql sql)
        {
            T resultT = db.FirstOrDefault<T>(sql);

            return resultT;
        }
        /// <summary>
        /// 获取第一条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(string sql, params object[] args)
        {
            T resultT = db.FirstOrDefault<T>(sql, args);

            return resultT;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public object Insert(object poco)
        {
            object resultT = db.Insert(poco);

            return resultT;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="autoIncrement"></param>
        /// <param name="poco"></param>
        /// <returns></returns>
        public object Insert(string tableName, string primaryKeyName, bool autoIncrement, object poco)
        {
            object resultT = db.Insert(tableName, primaryKeyName, autoIncrement, poco);

            return resultT;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <returns></returns>
        public object Insert(string tableName, string primaryKeyName, object poco)
        {
            object resultT = db.Insert(tableName, primaryKeyName, poco);

            return resultT;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="page">当前页</param>
        /// <param name="itemsPerPage">每页记录数</param>
        /// <param name="sql">sql</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Page<T> Page<T>(int page, int itemsPerPage, string sql, params object[] args)
        {
            Page<T> resultT = db.Page<T>(page, itemsPerPage, sql, args);

            return resultT;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Page<T> Page<T>(int page, int itemsPerPage, Sql sql)
        {
            Page<T> resultT = db.Page<T>(page, itemsPerPage, sql);

            return resultT;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Update<T>(string sql, params object[] args)
        {
            resultInt = db.Update<T>(sql, args);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        public int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue)
        {
            resultInt = db.Update(tableName, primaryKeyName, poco, primaryKeyValue);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <param name="primaryKeyValue"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue, IEnumerable<string> columns)
        {
            resultInt = db.Update(tableName, primaryKeyName, poco, primaryKeyValue, columns);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <returns></returns>
        public int Update(string tableName, string primaryKeyName, object poco)
        {
            resultInt = db.Update(tableName, primaryKeyName, poco);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="poco"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int Update(string tableName, string primaryKeyName, object poco, IEnumerable<string> columns)
        {
            resultInt = db.Update(tableName, primaryKeyName, poco, columns);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int Update(object poco, IEnumerable<string> columns)
        {
            resultInt = db.Update(poco, columns);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public int Update(object poco)
        {
            resultInt = db.Update(poco);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        public int Update(object poco, object primaryKeyValue)
        {
            resultInt = db.Update(poco, primaryKeyValue);

            return resultInt;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="poco"></param>
        /// <param name="primaryKeyValue"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int Update(object poco, object primaryKeyValue, IEnumerable<string> columns)
        {
            resultInt = db.Update(poco, primaryKeyValue, columns);

            return resultInt;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Update<T>(Sql sql)
        {
            resultInt = db.Update<T>(sql);

            return resultInt;
        }
    }
}
