using Wcivy.Data.Dapper;
using Wcivy.Data.Dapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper
{
    public class MSSqlRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// 构造函数（默认读取配置文件appSettings中key为SqlServerConnection的数据库连接字符串）
        /// </summary>
        public MSSqlRepository() : this("SqlServerConnection")
        {
        }

        /// <summary>
        /// 根据配置文件中appSettings的key获取对应的数据库连接字符串
        /// </summary>
        /// <param name="connectionString"></param>
        public MSSqlRepository(string connectionString) : base(new MSSqlUnitOfWork(connectionString))
        {
        }

        public MSSqlRepository(IUnitOfWork unitofwork) : base(unitofwork)
        {
        }
    }
}
