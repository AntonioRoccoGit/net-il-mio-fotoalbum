using System.Linq.Expressions;

namespace net_il_mio_fotoalbum.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        public T SearchAndInclude(Expression<Func<T, bool>> where, Expression<Func<T, object>> include);
        public List<T> SearchAndIncludeList(Expression<Func<T, bool>> where, Expression<Func<T, object>> include);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
