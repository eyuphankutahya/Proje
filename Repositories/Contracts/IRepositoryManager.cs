namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IGirisRepository Giris { get; }
        void Save();
    }
}