using DapperExtensions;
using System;
using System.Data;

namespace Wcivy.Data.Dapper.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabase GetDatabase();
        IDbTransaction GetTransaction();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
