using DapperExtensions;
using System;
using System.Data;

namespace Wcivy.Data.Dapper.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabase _database;
        private IDbTransaction _transaction;

        public UnitOfWork(IDatabase database)
        {
            _database = database;
        }

        public IDatabase GetDatabase()
        {
            return _database;
        }

        public IDbTransaction GetTransaction()
        {
            return _transaction;
        }
        public void BeginTransaction()
        {
            if (_transaction != null)
                throw new InvalidOperationException("事务已开启");
            _transaction = _transaction = _database.Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
                throw new InvalidOperationException("请开启事务");
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }

        public void Dispose()
        {
            if (_database != null)
                _database.Dispose();
        }
    }
}
