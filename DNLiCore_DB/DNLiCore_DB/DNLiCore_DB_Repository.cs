using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DNLiCore_DB
{
    public class Repository : IRepository
    {
       public DbContext context;
        public Repository(DbContext drewtest)
        {
            context = drewtest;
        }

        

        #region 增加
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add<T>(T entity) where T : class
        {
            if (context.Entry(entity).State != EntityState.Detached)
            {
                context.Entry<T>(entity).State = EntityState.Added;
            }
            context.Set<T>().Add(entity);
            return context.SaveChanges() > 0;
        }
        #endregion

        #region 增加-返回实体
        /// <summary>
        /// 增加-返回实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddT<T>(T entity) where T : class
        {
            if (context.Entry(entity).State != EntityState.Detached)
            {
                context.Entry<T>(entity).State = EntityState.Added;
            }
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }
        #endregion

        #region 增加-批量
        /// <summary>
        /// 增加-批量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public bool AddList<T>(IEnumerable<T> listEntity) where T : class
        {
            bool isSuccess = false;
            try
            {
                context.BulkInsert(listEntity);
                isSuccess = true;
            }
            catch (Exception)
            { }
            return isSuccess;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Del<T>(T entity) where T : class
        {
            context.Set<T>().Attach(entity);
            context.Entry<T>(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
        #endregion

        #region 删除-通过Id
        /// <summary>
        /// 删除-通过Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelId<T>(int id) where T : class
        {
            T entity = Get<T>(id);
            return Del(entity);
        }
        #endregion

        #region 删除-批量
        /// <summary>
        /// 删除-批量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public bool DelList<T>(IEnumerable<T> listEntity) where T : class
        {
            bool isSuccess = false;
            try
            {
                context.BulkDelete(listEntity);
                isSuccess = true;
            }
            catch (Exception)
            { }
            return isSuccess;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update<T>(T entity) where T : class
        {
            context.Set<T>().Attach(entity);
            context.Entry<T>(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        #endregion

        #region 修改-批量
        /// <summary>
        /// 修改-批量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public bool UpdateList<T>(IEnumerable<T> listEntity) where T : class
        {
            bool isSuccess = false;
            try
            {
                context.BulkUpdate(listEntity);
                isSuccess = true;
            }
            catch (Exception)
            { }
            return isSuccess;
        }
        #endregion

        #region 查询-通过主键
        /// <summary>
        /// 查询-通过主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get<T>(int id) where T : class
        {
            return context.Set<T>().Find(id);
        }
        #endregion

        #region 查询列表
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where == null)
            {
                return context.Set<T>().AsNoTracking().ToList();
            }
            else
            {
                return context.Set<T>().Where(where).AsNoTracking().ToList();
            }
        }
        #endregion

        #region 查询-分页
        /// <summary>
        /// 查询-分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="TotalCount">总记录数</param>
        /// <param name="TotalPage">总页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="WhereLambda">查询表达式</param>
        /// <param name="IsOrder">是否排序true：正序，false：倒叙</param>
        /// <returns></returns>
        public List<T> Pagination<T, S>(int PageIndex, int PageSize, out int TotalCount, out int TotalPage, Expression<Func<T, S>> OrderBy, Expression<Func<T, bool>> WhereLambda = null, bool IsOrder = true) where T : class
        {
            //分页的时候一定要注意 Order一定在Skip 之前
            IQueryable<T> QueryList = IsOrder == true ? context.Set<T>().OrderBy(OrderBy) : context.Set<T>().OrderByDescending(OrderBy);
            if (WhereLambda != null)
            {
                QueryList = QueryList.Where(WhereLambda);
            }
            TotalCount = QueryList.Count();
            TotalPage = TotalCount / PageSize;
            if (TotalPage == 0)
            {
                TotalPage = 1;
            }
            return QueryList.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList() ?? null;
        }
        #endregion

    }


}
