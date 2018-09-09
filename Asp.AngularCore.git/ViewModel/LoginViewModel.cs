using System.ComponentModel.DataAnnotations;

namespace Asp.AngularCore.git.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
