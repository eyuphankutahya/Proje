using Services.Contracts;

namespace Services
{

    public class ServicesManager : IServiceManager
    {
        private readonly IGirisService _girisService;
        private readonly IAuthService _authService;

        public ServicesManager(IGirisService girisService, IAuthService authService)
        {
            _girisService = girisService;
            _authService = authService;
        }

        public IGirisService GirisService => _girisService;

        public IAuthService AuthService => _authService;
    }
}