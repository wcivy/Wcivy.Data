using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper.Core
{
    public interface IOracleRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// 根据序列名称获取自增主键值
        /// </summary>
        /// <param name="sequenceName"></param>
        /// <returns></returns>
        object GetSequenceValue(string sequenceName);
    }
}
