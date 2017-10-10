using System.Collections.Generic;
using System.Data;
using Dapper;
using DapperExtensions;
using Wcivy.Data.Dapper.Query;
using System.Linq.Expressions;
using System;
using Wcivy.Data.Dapper.Extensions;

namespace Wcivy.Data.Dapper.Core
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly IDbTransaction DbTransaction;
        public IUnitOfWork UnitOfWork { get; set; }

        public IDbConnection DbContext { get { return UnitOfWork.GetDatabase().Connection; }}

        protected RepositoryBase(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
            DbTransaction = unitofwork.GetTransaction();
        }

        public TEntity Get(TKey id)
        {
            return UnitOfWork.GetDatabase().Get<TEntity>(id);
        }

        public IEntityBuilder<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return new EntityBuilder<TEntity>(UnitOfWork, predicate);
        }

        public IEnumerable<TEntity> Query(string sql, object param = null, int? commandTimeout = default(int?))
        {
            return UnitOfWork.GetDatabase().Connection.Query<TEntity>(sql, param, DbTransaction, commandTimeout: commandTimeout);
        }
        public DataTable ExecuteDataTable(string sql, object param = null, int? commandTimeout = default(int?))
        {
            var dataReader = ExecuteReader(sql, param, commandTimeout);
            return dataReader.ToDataTable();
        }
        public IDataReader ExecuteReader(string sql, object param = null, int? commandTimeout = default(int?))
        {
            return UnitOfWork.GetDatabase().Connection.ExecuteReader(sql, param, DbTransaction, commandTimeout);
        }

        public object ExecuteScalar(string sql, object param = null, int? commandTimeout = default(int?))
        {
            return UnitOfWork.GetDatabase().Connection.ExecuteScalar(sql, param, DbTransaction, commandTimeout);
        }

        public dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = default(int?))
        {
            return UnitOfWork.GetDatabase().Connection.QueryFirstOrDefault(sql, param, DbTransaction, commandTimeout);
        }

        public dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = default(int?))
        {
            return UnitOfWork.GetDatabase().Connection.QuerySingleOrDefault(sql, param, DbTransaction, commandTimeout);
        }
        public dynamic Insert(TEntity item)
        {
            return UnitOfWork.GetDatabase().Insert(item, DbTransaction);
        }

        public bool Update(TEntity item)
        {
            return UnitOfWork.GetDatabase().Update(item, DbTransaction);
        }

        public bool Delete(TEntity item)
        {
            return UnitOfWork.GetDatabase().Delete(item, DbTransaction);
        }

        public bool Delete(TKey id)
        {
            var item = UnitOfWork.GetDatabase().Get<TEntity>(id);
            return Delete(item);
        }

        public IEnumerable<TEntity> QueryStoredProcedure(string storedProcedure, object param = null)
        {
            return UnitOfWork.GetDatabase().Connection.Query<TEntity>(storedProcedure, param, DbTransaction, commandType: CommandType.StoredProcedure);
        }

        public int ExecuteStoredProcedure(string storedProcedure, object param = null)
        {
            return UnitOfWork.GetDatabase().Connection.Execute(storedProcedure, param, DbTransaction, commandType : CommandType.StoredProcedure);
        }
    }
}
