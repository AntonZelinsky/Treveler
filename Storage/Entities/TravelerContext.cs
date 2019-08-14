using Microsoft.EntityFrameworkCore;

namespace Storage.Entities
{
    public class TravelerContext : DbContext
    {
        public TravelerContext(DbContextOptions<TravelerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}