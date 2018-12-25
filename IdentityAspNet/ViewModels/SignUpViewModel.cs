using System.ComponentModel.DataAnnotations;

namespace IdentityAspNet.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Pswd { get; set; }

        [Display(Name = "Repeat")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Pswd")]
        public string Repeat { get; set; }
    }
}
