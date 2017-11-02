using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public abstract class BaseEntity { }
    public class User : BaseEntity
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
        [Required]
        [Compare(nameof(password))]
        [DataType(DataType.Password)]
        public string confirm { get; set; }
    }

    public class Login : BaseEntity
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