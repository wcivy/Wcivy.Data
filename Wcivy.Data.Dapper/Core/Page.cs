using System.Collections.Generic;
using DapperExtensions;

namespace Wcivy.Data.Dapper.Core
{
    public class Page
    {
        /// <summary>
        /// 条件
        /// </summary>
        public IPredicate predicate { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public   IList<ISort> sort { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int resultsPerPage { get; set; }
    }
}
