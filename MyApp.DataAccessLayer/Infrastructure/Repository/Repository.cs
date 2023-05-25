using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _Context;
        private DbSet<T> _DbSet;
        public Repository(DatabaseContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }

        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _DbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.ToList();
        }
        public IQueryable<T> GetQueryable()
        {
            return _DbSet;
        }
        public IQueryable<T> TestGetAll()
        {
            return _DbSet;
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.Where(predicate).FirstOrDefault();
        }
    }
}
