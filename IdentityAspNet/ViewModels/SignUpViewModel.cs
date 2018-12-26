using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityAspNet.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Name Surname required!")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Pswd { get; set; }

        [Display(Name = "Repeat")]
        [Required(ErrorMessage = "Repeat password is required!")]
        [DataType(DataType.Password)]
        [Compare("Pswd")]
        public string Repeat { get; set; }

        [Required(ErrorMessage = "Birthday is required!")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public bool Gender { get; set; }
    }
}
