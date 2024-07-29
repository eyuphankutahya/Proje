using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        //??
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where(expression).SingleOrDefault()
                                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
    }
}
