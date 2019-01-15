using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DNLiCore_DB
{
   public interface ISqlServerHelper
    {
        int GetMaxID(string FieldName, string TableName);

        bool Exists(string strSql, params SqlParameter[] cmdParms);

        int ExecuteSql(string SQLString);

        void ExecuteSqlTran(ArrayList SQLStringList);

        int ExecuteSql(string SQLString, string content);

         int ExecuteSqlInsertImg(string strSQL, byte[] fs);

        object GetSingle(string SQLString);
        object GetSingle(string SQLString, params SqlParameter[] cmdParms);

        DataSet Query(string SQLString);
        DataSet Query(string SQLString, params SqlParameter[] cmdParms);

        int ExecuteSql(string SQLString, params SqlParameter[] cmdParms);

        void ExecuteSqlTran(Hashtable SQLStringList);

        DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName);
       
    }
}
