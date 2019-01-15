using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DNLiCore_DB
{
    public interface IRepository
    {


       
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add<T>(T entity) where T : class;
        /// <summary>
        /// 增加-返回实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddT<T>(T entity) where T : class;
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        bool AddList<T>(IEnumerable<T> listEntity) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Del<T>(T entity) where T : class;
        /// <summary>
        /// 删除-主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelId<T>(int id) where T : class;
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        bool DelList<T>(IEnumerable<T> listEntity) where T : class;

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update<T>(T entity) where T : class;
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        bool UpdateList<T>(IEnumerable<T> listEntity) where T : class;

        /// <summary>
        /// 查询-主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(int id) where T : class;

        /// <summary>
        /// 列表查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        List<T> GetList<T>(Expression<Func<T, bool>> where=null) where T : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="totalCount"></param>
        /// <param name="totalPage"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLamda"></param>
        /// <returns></returns>      
        List<T> Pagination<T,S>(int PageIndex, int PageSize, out int TotalCount,out int TotalPage, Expression<Func<T, S>> OrderBy, Expression<Func<T, bool>> WhereLambda = null, bool IsOrder = true) where T : class;
    }
}
