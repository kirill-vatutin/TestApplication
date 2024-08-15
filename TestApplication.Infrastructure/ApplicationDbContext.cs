using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestApplication.Domain.Models;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastucture
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSnakeCaseNamingConvention();
                optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries<ITimeEntity>();

            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.UpdateCreatedTime() ;
                }
                else if (entry.State is EntityState.Modified)
                {
                    entry.Entity.UpdateUpdatedTime();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
