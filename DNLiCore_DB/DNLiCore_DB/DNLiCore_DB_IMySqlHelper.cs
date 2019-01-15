using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;


namespace DNLiCore_DB //�����޸ĳ�ʵ����Ŀ�������ռ�����
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
