using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        [Required(ErrorMessage = "Username required")]
        [DataType(DataType.Text)]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }

        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}