using System.Security.Cryptography.X509Certificates;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Proje.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        // public IActionResult Create()
        // {
        //     return View(new UserDtoForCreation()
        //     {
        //         Roles = new HashSet<string>(_manager
        //         .AuthService.Roles.Select(r => r.Name)).ToList()
        //     });
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(FromForm UserDtoForCreation userDto)
        // {
        //     var result = await _manager.AuthService.CreateUser(userDto);
        //     return result.Succeeded ? RedirectToAction((Index)) : View();



        // }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id

            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
        {
            var result = await _manager.AuthService.ResetPassword(model);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }

    }

}