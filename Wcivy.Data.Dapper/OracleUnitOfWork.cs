using DapperExtensions;
using Wcivy.Data.Dapper.Core;

namespace Wcivy.Data.Dapper
{
    public class OracleUnitOfWork : UnitOfWork
    {
        /// <summary>
        /// 构造函数（默认读取配置文件appSettings中key为OracleConnection的数据库连接字符串）
        /// </summary>
        public OracleUnitOfWork() : this("OracleConnection")
        {
        }

        public OracleUnitOfWork(string connectionString)
            : base(DbFactory.GetDatabase(connectionString, DataBaseType.Orcale))
        {
        }

        public OracleUnitOfWork(IDatabase database) : base(database)
        {
        }
    }
}
