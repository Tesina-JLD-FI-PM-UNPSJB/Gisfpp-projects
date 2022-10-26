using Gisfpp_projects.Shared.Model;

namespace Gisfpp_projects.Shared.Services
{
    public class Paginator<T, V, K> where T : IQueryable<V> where V: class
    {
        private readonly T _target;
        public Func<V, K> _order { get; set; }

        public Paginator(T target)
        {
            _target = target;
        }

        public Paginator(T target, Func<V, K> order) : this(target)
        {
            _order = order;
        }

        public ResultPage<V> GetPage(int numberPage, int sizePage) {
            var position = sizePage * (numberPage - 1);
            var totalElements = _target.Count();

            var queryable = _target;
            if ( _order is not null )
            {
                queryable.OrderBy( p => _order(p) );
            }

            var resultQuery = queryable.Skip(position)
                                    .Take(sizePage)
                                    .ToList();

            var result = new ResultPage<V>();
            result.result = resultQuery;
            result.totalElements = totalElements;
            result.hasMoreElements = resultQuery.Count < sizePage
                                        ? false
                                        : totalElements > (numberPage * sizePage);
            result.numberPage = numberPage;
            result.sizePage = sizePage;

            return result;
        }
    }
}
