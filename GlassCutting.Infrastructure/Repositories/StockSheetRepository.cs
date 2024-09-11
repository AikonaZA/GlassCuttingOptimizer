using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GlassCutting.Infrastructure.Repositories;

public class StockSheetRepository(ApplicationDbContext context) : IStockSheetRepository
{
    public async Task<IEnumerable<StockSheet>> GetAllStockSheetsAsync()
    {
        return await context.StockSheets.ToListAsync();
    }

    public async Task<StockSheet> GetStockSheetByIdAsync(int id)
    {
        return await context.StockSheets.FindAsync(id);
    }

    public async Task AddStockSheetAsync(StockSheet stockSheet)
    {
        await context.StockSheets.AddAsync(stockSheet);
        await context.SaveChangesAsync();
    }
}
