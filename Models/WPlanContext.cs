using Microsoft.EntityFrameworkCore;

namespace wplan.Models
{
    public class WPlanContext : DbContext
    {
        public WPlanContext(DbContextOptions<WPlanContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Wedding> weddings { get; set; }
        public DbSet<Guest> guests { get; set; }
    }
}