using Entities.Models;

namespace Services.Contracts
{
    public interface IGirisService
    {
        IEnumerable<Giris> GetAllGirisler(bool trackChanges);
    }
}
