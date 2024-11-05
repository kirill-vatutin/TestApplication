using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestApplication.Domain.Models.Entities;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastructure;

public class ApplicationDbContext(
    IConfiguration configuration) : DbContext
{
    private const string DATABASE = "Database";
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private static ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<ITimeEntity>();

        foreach (var entry in entries)
        {
            if (entry.State is EntityState.Added)
            {
                entry.Entity.UpdateCreatedTime();
            }
            else if (entry.State is EntityState.Modified)
            {
                entry.Entity.UpdateUpdatedTime();
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
