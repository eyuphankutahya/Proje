using System.ComponentModel.DataAnnotations;

namespace Proje.Models
{
    public class LoginModel
    {
        private string? _returnurl;

        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string? Email { get; set; } //??
        [Required(ErrorMessage = "isim alanı boş geçilemez")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnurl is null)
                {
                    return "/";
                }
                else
                {
                    return _returnurl;
                }
            }

            set
            {
                _returnurl = value;
            }
        }
    }
}