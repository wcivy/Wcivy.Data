using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper.Query
{
    public interface IEntityBuilder<T> where T : class
    {
        /// <summary>
        /// 确定序列是否包含任何元素。
        /// </summary>
        /// <returns></returns>
        bool Any();
        IEnumerable<T> AsEnumerable();
        /// <summary>
        /// 从 System.Collections.Generic.IEnumerable 创建一个数组。
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
        /// <summary>
        /// 从 System.Collections.Generic.IEnumerable 创建一个 System.Collections.Generic.List。
        /// </summary>
        /// <returns></returns>
        IList<T> ToList();
        /// <summary>
        /// 返回序列中的元素数量。
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// 返回序列的唯一元素；如果该序列并非恰好包含一个元素，则会引发异常。
        /// </summary>
        /// <returns></returns>
        T Single();
        /// <summary>
        /// 返回序列中的唯一元素；如果该序列为空，则返回默认值；如果该序列包含多个元素，此方法将引发异常。
        /// </summary>
        /// <returns></returns>
        T SingleOrDefault();
        /// <summary>
        /// 返回序列中的第一个元素；如果序列中不包含任何元素，则返回默认值。
        /// </summary>
        /// <returns></returns>
        T FirstOrDefault();
        /// <summary>
        /// 根据键按升序对序列的元素排序。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEntityBuilder<T> OrderBy(Expression<Func<T, object>> expression);
        /// <summary>
        /// 根据键按降序对序列的元素排序。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEntityBuilder<T> OrderByDescending(Expression<Func<T, object>> expression);
        /// <summary>
        /// 设置sql执行过期时间
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IEntityBuilder<T> Timeout(int timeout);
        /// <summary>
        /// 返回分页结果集
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEntityBuilder<T> Page(int pageNum, int pageSize);
    }
}
