using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
// using AutoMapper; PAKET YÜKLEMEK GEREKİYOR
namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        // private readonly IMapper _mapper; ??

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)//, IMapper mapper)??
        {
            _roleManager = roleManager;
            _userManager = userManager;
            // _mapper = mapper; ??
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            throw new NotImplementedException();
            // //??
            // var user= _mapper.Map<IdentityUser>(userDto);
            // var result = await _userManager.CreateAsync(user, userDto.Password);

            // if (!result.Succeeded)
            // {
            //     throw new Exception("user oluşma başarısız");
            // }

            // if (userDto.Roles.Count > 0)
            // {
            //     var roles = await _userManager.AddToRolesAsync(user, userDto.Roles);
            //     if (!roles.Succeeded)
            //     {
            //         throw new Exception("rol atama başarısız");
            //     }
            // }
            // return result;
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            throw new NotImplementedException();
            //??
            // return _userManager.Users.ToList();
        }



        //??  // hata veriyodu o yüzden kismi yorum satırınaaldım 
        public async Task<IdentityUser> GetOneUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            // if(user in not null)
            return user;
            throw new Exception("Kullanıcı bulunamadı");
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        {
            //??
            var user = await GetOneUser(model.UserName);
            if (user is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, model.Password);
                return result;
            }
            throw new Exception("User not found");
            // await _userManager.RemovePasswordAsync(user);
            // var result = await _userManager.AddPasswordAsync(user, model.Password);
            // return result;
            // throw new NotImplementedException();
        }



        // public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        // {
        //     var user = _mapper.Map<IdentityUser>(userDto);
        //     var result = await _userManager.CreateAsync(user, userDto.Password);

        //     if (!result.Succeeded)
        //     {
        //         throw new Exception("user oluşma başarısız");
        //     }

        //     if (userDto.Roles.Count > 0)
        //     {
        //         var roles = await _userManager.AddToRolesAsync(user, userDto.Roles);
        //         if (!roles.Succeeded)
        //         {
        //             throw new Exception("rol atama başarısız");
        //         }
        //     }
        //     return result;

        // }


        public IEnumerable<IdentityUser> IdentityUser()
        {
            return _userManager.Users.ToList();

        }




        // public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        //  {
        // //     var user = await _userManager.GetOneUser(model.UserName);
        // //     if (user is not null)
        // //     {
        // //         await _userManager.RemovePasswordAsync(user);
        // //         var result = await _userManager.AddPasswordAsync(user, model.Password);
        // //         return result;
        // //     }
        // //     throw new Exception("User not found");
        //  }



    }
}