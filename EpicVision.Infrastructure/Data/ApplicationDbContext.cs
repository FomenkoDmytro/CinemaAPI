using EpicVision.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpicVision.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "DefaultConnection";
                optionsBuilder.UseSqlServer(connectionString, options =>
                    options.MigrationsAssembly("EpicVision.Infrastructure"));
            }
        }
    }
}


