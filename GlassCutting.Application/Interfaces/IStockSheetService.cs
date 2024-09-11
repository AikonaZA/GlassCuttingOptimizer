using GlassCutting.Core.Entities;

namespace GlassCutting.Application.Interfaces;

public interface IStockSheetService
{
    Task<IEnumerable<StockSheet>> GetAllStockSheetsAsync();

    Task AddStockSheetAsync(StockSheet stockSheet);

    Task<StockSheet> GetStockSheetByIdAsync(int id);
}