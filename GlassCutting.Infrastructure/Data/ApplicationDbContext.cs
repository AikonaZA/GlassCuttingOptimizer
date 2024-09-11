using GlassCutting.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlassCutting.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<StockSheet> StockSheets { get; set; }
    public DbSet<GlassPanel> GlassPanels { get; set; }
    public DbSet<CutLayout> CutLayouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure entity relationships and constraints here
        modelBuilder.Entity<CutPosition>()
            .HasOne<CutLayout>()
            .WithMany(c => c.CutPositions)
            .HasForeignKey(p => p.CutLayoutId);
    }
}

