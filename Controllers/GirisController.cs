using Proje.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace Proje.Controllers
{
    public class GirisController : Controller
    {
        private readonly IServiceManager _manager;
        public GirisController(IServiceManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {

            var model = _manager.GirisService.GetAllGirisler(false);
            return View(model);
            //return _context.GirisModel.ToList();
        }
    }


}
