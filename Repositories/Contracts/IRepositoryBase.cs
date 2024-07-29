// mantığı oturmadı. 
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {

        IQueryable<T> FindAll(bool trackChanges);

        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        void Create(T entity);//??
    }
}