using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;

public interface IStockSheetRepository
{
    Task AddStockSheetAsync(StockSheet stockSheet);

    Task<IEnumerable<StockSheet>> GetAllStockSheetsAsync();

    Task<StockSheet> GetStockSheetByIdAsync(int id);
}