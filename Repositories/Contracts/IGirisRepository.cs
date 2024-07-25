using Entities.Models;

namespace Repositories.Contracts
{
    public interface IGirisRepository : IRepositoryBase<Giris>
    {
        IQueryable<Giris> GetAllGirisler(bool trackChanges);

    }
}