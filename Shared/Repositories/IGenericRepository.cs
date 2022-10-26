namespace Gisfpp_projects.Shared.Repositories
{
    public interface IGenericRepository<T, K>
    {
        public K Create(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public T? FindById(K id);

        public IEnumerable<T> GetAll();
    }
}