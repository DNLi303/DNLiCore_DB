using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNLiCore_DB
{
    public interface IPetaPocoHelper
    {
        #region 执行sql
        int Execute(Sql sql);
        int Execute(string sql, params object[] args);
        T ExecuteScalar<T>(string sql, params object[] args);
        T ExecuteScalar<T>(Sql sql);
        #endregion

        #region 增加
        object Insert(object poco);
        object Insert(string tableName, string primaryKeyName, bool autoIncrement, object poco);
        object Insert(string tableName, string primaryKeyName, object poco);
        #endregion

        #region 修改
        int Update<T>(string sql, params object[] args);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update(string tableName, string primaryKeyName, object poco);
        int Update(string tableName, string primaryKeyName, object poco, IEnumerable<string> columns);
        int Update(object poco, IEnumerable<string> columns);
        int Update(object poco);
        int Update(object poco, object primaryKeyValue);
        int Update(object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update<T>(Sql sql);
        #endregion

        #region 删除
        int Delete(object poco);
        int Delete<T>(Sql sql);
        int Delete<T>(string sql, params object[] args);
        int Delete(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Delete<T>(object pocoOrPrimaryKey);
        int Delete(string tableName, string primaryKeyName, object poco);
        #endregion

        #region 查询
         List<T> Fetch<T>(int page, int itemsPerPage, string sql, params object[] args);
         List<T> Fetch<T>(Sql sql);
         List<T> Fetch<T>(int page, int itemsPerPage, Sql sql);
         List<T> Fetch<T>(string sql, params object[] args);
         T First<T>(Sql sql);
         T First<T>(string sql, params object[] args);
         T FirstOrDefault<T>(Sql sql);
         T FirstOrDefault<T>(string sql, params object[] args);
         Page<T> Page<T>(int page, int itemsPerPage, string sql, params object[] args);
         Page<T> Page<T>(int page, int itemsPerPage, Sql sql);
        #endregion

        
    }
}
