using System;
using System.ComponentModel.DataAnnotations;

namespace wplan.Models
{
    public abstract class BaseEntity 
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    public class User : BaseEntity
    {
        public int userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}