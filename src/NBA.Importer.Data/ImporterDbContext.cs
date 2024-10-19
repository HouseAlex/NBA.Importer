using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NBA.Importer.Data.Entities;

namespace NBA.Importer.Data;

public class ImporterDbContext : DbContext
{
    public ImporterDbContext(DbContextOptions<ImporterDbContext> options)
        : base(options)
    {
    }

    public DbSet<BoxScore> BoxScores { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Team> Teams { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        ////modelBuilder.ApplyQuartzConfigurations(); // Figure out if needed
    }
}
