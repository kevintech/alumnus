using System.ComponentModel.DataAnnotations;

namespace alumnus.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Mantener mi sesion")]
        public bool RememberMe { get; set; }
    }
}
