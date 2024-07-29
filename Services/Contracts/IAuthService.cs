using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }

        IEnumerable<IdentityUser> GetAllUsers();

        Task<IdentityUser> GetOneUser(string userName);

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);

    }
}