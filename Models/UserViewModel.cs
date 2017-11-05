using System;
using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public class UserViewModel : BaseEntity
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2)]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2)]
        public string lastname { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(password))]
        [DataType(DataType.Password)]
        // [Compare("password", ErrorMessage = "Password and confirmation must match")]
        public string confirm { get; set; }
    }

    public class LoginViewModel : BaseEntity
    {
        [Display(Name = "Email")]
        [Required] 
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}