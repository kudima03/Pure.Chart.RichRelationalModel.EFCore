using Microsoft.EntityFrameworkCore;
using Pure.Chart.RichRelationalModel.EFCore.Models;
using Pure.Chart.RichRelationalModel.EFCore.Models.Configurations;

namespace Pure.Chart.RichRelationalModel.EFCore;

public sealed class ChartDbContext(DbContextOptions<ChartDbContext> options)
    : DbContext(options)
{
    public DbSet<ChartEFCoreModel> Charts => Set<ChartEFCoreModel>();

    public DbSet<ChartTypeEFCoreModel> Types => Set<ChartTypeEFCoreModel>();

    public DbSet<AxisEFCoreModel> Axes => Set<AxisEFCoreModel>();

    public DbSet<SeriesEFCoreModel> Series => Set<SeriesEFCoreModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new SeriesConfiguration());
        _ = modelBuilder.ApplyConfiguration(new AxisConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ChartTypeConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ChartConfiguration());
    }
}
