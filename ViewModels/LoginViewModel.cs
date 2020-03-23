using System.ComponentModel.DataAnnotations;

namespace GalaxiaApi.ViewModels
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required] public bool RememberMe { get; set; }
    }
}