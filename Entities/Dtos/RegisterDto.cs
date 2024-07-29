using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "UserName boş olamaz")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password boş olamaz")]
        // [MinLength(6, ErrorMessage = "Sifre en az 6 karakter uzunlu olmalıdır")]
        public string? Password { get; init; }
        [Required(ErrorMessage = "Email boş olamaz")]
        // [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin")]
        public string? Email { get; init; }

    }
}