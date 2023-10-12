using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Interface;
using System.Linq.Expressions;

namespace net_il_mio_fotoalbum.Services
{

    public class CrudHelper<T, D> : IRepository<T> where T : class where D : DbContext
    {

        public readonly D _context;
        private readonly DbSet<T> _dbSet;

        public CrudHelper(D context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T SearchAndInclude(Expression<Func<T, bool>> where, Expression<Func<T, object>> include)
        {
            T item = _dbSet.Where(where).Include(include).FirstOrDefault();
            return item;
        }

        public List<T> SearchAndIncludeList(Expression<Func<T, bool>> where, Expression<Func<T, object>> include)
        {
            List<T> items = _dbSet.Where(where).Include(include).ToList();
            return items;
        }


        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T entity)
        {

            return true;
        }
    }
}
