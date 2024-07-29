using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{

    public record UserDtoForCreation : UserDto
    {
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string? Password { get; init; }

    }
}