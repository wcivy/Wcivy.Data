using System;
using System.Collections.Generic;
using DapperExtensions;
using System.Data;
using System.Linq.Expressions;
using Wcivy.Data.Dapper.Query;

namespace Wcivy.Data.Dapper.Core
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        IDbConnection DbContext { get; }

        /// <summary>
        /// 通过主键获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);

        IEntityBuilder<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Query(string sql, object param = null, int? commandTimeout = default(int?));
        /// <summary>
        /// sql语句查询，返回DataTable的结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        DataTable ExecuteDataTable(string sql, object param = null, int? commandTimeout = default(int?));
        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string sql, object param = null, int? commandTimeout = default(int?));

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        object ExecuteScalar(string sql, object param = null, int? commandTimeout = default(int?));

        /// <summary>
        /// 获取第一条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = default(int?));

        /// <summary>
        /// 获取唯一记录
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = default(int?));

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        dynamic Insert(TEntity item);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(TEntity item);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Delete(TEntity item);

        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TKey id);

        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        IEnumerable<TEntity> QueryStoredProcedure(string storedProcedure, object param = null);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int ExecuteStoredProcedure(string storedProcedure, object param = null);
    }
}
