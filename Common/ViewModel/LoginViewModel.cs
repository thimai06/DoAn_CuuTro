using System.ComponentModel.DataAnnotations;

namespace Common.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Passwords { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Passwords { get; set; }

        [Required]
        public string ConfirmPasswords { get; set; }
    }
}
