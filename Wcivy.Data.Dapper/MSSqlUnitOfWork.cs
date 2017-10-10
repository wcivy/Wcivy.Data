using DapperExtensions;
using Wcivy.Data.Dapper.Core;

namespace Wcivy.Data.Dapper
{
    public class MSSqlUnitOfWork : UnitOfWork
    {
        /// <summary>
        /// 构造函数（默认读取配置文件appSettings中key为SqlServerConnection的数据库连接字符串）
        /// </summary>
        public MSSqlUnitOfWork() : this("SqlServerConnection")
        {
        }

        public MSSqlUnitOfWork(string connectionString)
            : base(DbFactory.GetDatabase(connectionString, DataBaseType.SqlServer))
        {
        }

        public MSSqlUnitOfWork(IDatabase database) : base(database)
        {
        }
    }
}
