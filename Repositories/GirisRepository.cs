using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{

    public class GirisRepository : RepositoryBase<Giris>, IGirisRepository
    {
        public GirisRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<Giris> GetAllGirisler(bool trackChanges) => FindAll(trackChanges);

    }
}