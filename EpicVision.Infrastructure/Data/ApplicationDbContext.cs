using EpicVision.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpicVision.Infrastructure_DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DurationUnit> DurationUnits { get; set; }
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


