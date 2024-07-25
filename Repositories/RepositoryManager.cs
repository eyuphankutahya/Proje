using Repositories.Contracts;

namespace Repositories
{

    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IGirisRepository _girisRepository;

        public RepositoryManager(IGirisRepository girisRepository, RepositoryContext context)
        {
            _girisRepository = girisRepository;
            _context = new RepositoryContext();
        }


        public IGirisRepository Giris => _girisRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}