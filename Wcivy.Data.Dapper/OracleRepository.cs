using Wcivy.Data.Dapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper
{
    public class OracleRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey> , IOracleRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// 构造函数（默认读取配置文件appSettings中key为OracleConnection的数据库连接字符串）
        /// </summary>
        public OracleRepository() : this("OracleConnection")
        {
        }

        /// <summary>
        /// 根据配置文件中appSettings的key获取对应的数据库连接字符串
        /// </summary>
        /// <param name="connectionString"></param>
        public OracleRepository(string connectionString) : base(new OracleUnitOfWork(connectionString))
        {
        }

        public OracleRepository(IUnitOfWork unitofwork) : base(unitofwork)
        {
        }

        public virtual object GetSequenceValue(string sequenceName)
        {
            //object sequence = null;
            //var rows = QuerySingleOrDefault(string.Format("select {0}.nextval from dual", sequenceName));
            ////foreach (var r in rows)
            ////{
            ////    sequence = r.Value;
            ////}
            //sequence = ((IDictionary<string, object>)rows).Values.SingleOrDefault();
            return ExecuteScalar(string.Format("select {0}.nextval from dual", sequenceName)); 
        }
    }
}
