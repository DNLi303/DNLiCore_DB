using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DNLiCore_DB
{
    public interface ISqlLiteHelper
    {
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSql(string sql);

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable Query(string sql);
    }
}
