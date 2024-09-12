using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GlassCutting.Infrastructure.Repositories;

public class DatabaseRepository(ApplicationDbContext context) : IDatabaseRepository
{
    public async Task ClearDatabaseAsync()
    {
        // Delete all data from tables
        await context.Database.ExecuteSqlRawAsync("DELETE FROM GlassPanels");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM StockSheets");
        await context.SaveChangesAsync();
    }

    public async Task ResetDatabaseAsync()
    {
        // Reset the database by dropping and recreating the schema
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }
}
