using System.Linq.Expressions;

namespace MvcMovie.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
