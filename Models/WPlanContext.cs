using Microsoft.EntityFrameworkCore;

namespace wplan.Models
{
    public class WPlanContext : DbContext
    {
        public WPlanContext(DbContextOptions<WPlanContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<User> Weddings { get; set; }
        public DbSet<User> Guests { get; set; }
    }
}