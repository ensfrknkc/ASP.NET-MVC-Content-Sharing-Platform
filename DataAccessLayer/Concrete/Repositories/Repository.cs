using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _object;

        public Repository(Context context)
        {
            _context = context;
            _object = _context.Set<T>();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            _context.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            _context.SaveChanges();
        }
    }
}
