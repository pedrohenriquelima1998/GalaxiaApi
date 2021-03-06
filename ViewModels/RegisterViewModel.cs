using System.ComponentModel.DataAnnotations;

namespace GalaxiaApi.ViewModels
{
    public class RegisterViewModel
    {
        [Required] public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}