using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;


namespace DNLiCore_DB //可以修改成实际项目的命名空间名称
{
  
    public interface IMySqlHelper
    {
        DataSet Query(string SQLString);
        DataSet Query(string SQLString, params MySqlParameter[] cmdParms);

        object GetSingle(string SQLString);
        object GetSingle(string SQLString, params MySqlParameter[] cmdParms);

        void ExecuteMySqlTran(Hashtable SQLStringList);

        int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms);

        void ExecuteSqlTran(Hashtable SQLStringList);
    }
}
