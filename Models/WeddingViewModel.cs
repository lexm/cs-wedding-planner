using System;
using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Display(Name = "Wedder 1")]
        [Required]
        [MinLength(2)]
        public string wedder1 { get; set; }
        [Display(Name = "Wedder 1")]
        [Required]
        [MinLength(2)]
        public string wedder2 { get; set; }
        [Display(Name = "Date")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Display(Name = "Address")]
        [Required]
        [MinLength(2)]
        public string address { get; set; }
    }
}