using Microsoft.EntityFrameworkCore;

namespace Shadower.Data
{
    public class ShadowerDbContext : DbContext
    {
        public ShadowerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
