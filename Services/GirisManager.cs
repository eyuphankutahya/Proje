using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class GirisManager : IGirisService
    {
        private readonly IRepositoryManager _manager;

        public GirisManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Giris> GetAllGirisler(bool trackChanges)
        {
            return _manager.Giris.GetAllGirisler(trackChanges);
        }
    }
}