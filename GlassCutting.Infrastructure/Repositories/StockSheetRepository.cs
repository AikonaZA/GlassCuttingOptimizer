using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;

namespace GlassCutting.Infrastructure.Repositories;
public class StockSheetRepository(ApplicationDbContext context) : IStockSheetRepository
{
    public IEnumerable<StockSheet> GetAllStockSheets()
    {
        return [.. context.StockSheets];
    }

    public StockSheet GetStockSheetById(int id)
    {
        return context.StockSheets.Find(id);
    }
}
