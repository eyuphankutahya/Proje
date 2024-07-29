using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Entities.Dtos
{

    public record ResetPasswordDto
    {
        public string? UserName { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string? ConfirmPassword { get; init; }
    }
}