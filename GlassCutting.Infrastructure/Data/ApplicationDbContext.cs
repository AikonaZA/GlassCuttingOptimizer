using GlassCutting.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<StockSheet> StockSheets { get; set; }
    public DbSet<GlassPanel> GlassPanels { get; set; }
    public DbSet<CutLayout> CutLayouts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

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

