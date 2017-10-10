using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Wcivy.Data.Dapper.Core;

namespace Wcivy.Data.Dapper.Query
{
    sealed class EntityBuilder<T> : IEntityBuilder<T> where T : class
    {
        private readonly IUnitOfWork _session;
        private readonly Expression<Func<T, bool>> _expression;
        private readonly IList<ISort> _sort;
        private int? _pageIndex;
        private int? _pageSize;
        private int? _timeout;

        public EntityBuilder(IUnitOfWork session, Expression<Func<T, bool>> expression)
        {
            _session = session;
            _expression = expression;
            _sort = new List<ISort>();
        }

        private IEnumerable<T> ResolveEnities()
        {
            IPredicateGroup predicate = QueryBuilder<T>.FromExpression(_expression);

            if (_pageIndex != null && _pageSize != null)
                return _session.GetDatabase().GetPage<T>(predicate ?? null, _sort, _pageIndex.GetValueOrDefault(), _pageSize.GetValueOrDefault(), _timeout, false);
            else
                return _session.GetDatabase().GetList<T>(predicate ?? null, _sort, _session.GetTransaction(), _timeout, false);
        }

        public IEnumerable<T> AsEnumerable()
        {
            return ResolveEnities();
        }

        public bool Any()
        {
            return ResolveEnities().Any();
        }

        public T[] ToArray()
        {
            return ResolveEnities().ToArray();
        }

        public IList<T> ToList()
        {
            return ResolveEnities().ToList();
        }

        public int Count()
        {
            return ResolveEnities().Count();
        }

        public T Single()
        {
            return ResolveEnities().Single();
        }

        public T SingleOrDefault()
        {
            return ResolveEnities().SingleOrDefault();
        }

        public T FirstOrDefault()
        {
            return ResolveEnities().FirstOrDefault();
        }

        public IEntityBuilder<T> OrderBy(Expression<Func<T, object>> expression)
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            if (propertyInfo == null) return this;

            var sort = new Sort
            {
                PropertyName = propertyInfo.Name,
                Ascending = true
            };
            _sort.Add(sort);

            return this;
        }

        public IEntityBuilder<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(expression) as PropertyInfo;
            if (propertyInfo == null) return this;

            var sort = new Sort
            {
                PropertyName = propertyInfo.Name,
                Ascending = false
            };
            _sort.Add(sort);

            return this;
        }

        public IEntityBuilder<T> Timeout(int timeout)
        {
            _timeout = timeout;
            return this;
        }

        public IEntityBuilder<T> Page(int pageIndex, int pageSize)
        {
            _pageIndex = pageIndex;
            _pageSize = pageSize;
            return this;
        }
    }
}
