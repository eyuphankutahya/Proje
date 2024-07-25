using Services.Contracts;

namespace Services
{

    public class ServicesManager : IServiceManager
    {
        private readonly IGirisService _girisService;

        public ServicesManager(IGirisService girisService)
        {
            _girisService = girisService;
        }

        public IGirisService GirisService => _girisService;
    }
}