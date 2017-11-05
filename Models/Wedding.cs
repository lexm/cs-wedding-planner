using System;
using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public class Wedding : BaseEntity
    {
        public int weddingid { get; set; }
        public string wedder1 { get; set; }
        public string wedder2 { get; set; }
        public DateTime date { get; set; }
        public string address { get; set; }
    }
}