using Microsoft.EntityFrameworkCore;
using Data.Model;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DictionaryItem> DictionaryItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=rewol;Username=postgres;Password=postgres");
            }
        }
    }
}