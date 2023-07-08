using System.ComponentModel.DataAnnotations;

namespace MinvoiceWebhook.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; }

        
    }
}
