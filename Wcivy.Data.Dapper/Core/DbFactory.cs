using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper.Core
{
    public class DbFactory
    {
        public static IDatabase GetDatabase(string key, DataBaseType type)
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("数据库连接字符串不能为空！");

            IDbConnection cnn = null;
            IDapperExtensionsConfiguration config = null;
            switch (type)
            {
                case DataBaseType.Orcale:
                    config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new OracleDialect());
                    cnn = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString);
                    break;
                case DataBaseType.SqlServer:
                    config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect());
                    cnn = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
                default:
                    throw new NotImplementedException("尚未实现对该数据库的支持！");
            }
            var sqlGenerator = new SqlGeneratorImpl(config);
            return new Database(cnn, sqlGenerator);
        }
    }
}
