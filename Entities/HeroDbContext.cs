using Microsoft.EntityFrameworkCore;

namespace hero.api.Entities
{
    public class HeroDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public HeroDbContext()
        {
        }

        public HeroDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
