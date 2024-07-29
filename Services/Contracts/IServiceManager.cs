namespace Services.Contracts
{

    public interface IServiceManager
    {
        IGirisService GirisService { get; }

        IAuthService AuthService { get; }

    }
}