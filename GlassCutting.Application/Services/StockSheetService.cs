using GlassCutting.Application.Interfaces;
using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Services;

public class StockSheetService(IStockSheetRepository stockSheetRepository) : IStockSheetService
{
    public async Task<IEnumerable<StockSheet>> GetAllStockSheetsAsync()
    {
        return await stockSheetRepository.GetAllStockSheetsAsync();
    }

    public async Task AddStockSheetAsync(StockSheet stockSheet)
    {
        await stockSheetRepository.AddStockSheetAsync(stockSheet);
    }

    public async Task<StockSheet> GetStockSheetByIdAsync(int id)
    {
        return await stockSheetRepository.GetStockSheetByIdAsync(id);
    }
}
