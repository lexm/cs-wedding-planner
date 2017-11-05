using System;
using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public class Guest : BaseEntity
    {
        public int guestid { get; set; }
        public int userid { get; set; }
        public int weddingid { get; set; }
        public bool rsvp { get; set; }
    }
}