using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;
public interface IStockSheetRepository
{
    IEnumerable<StockSheet> GetAllStockSheets();
    StockSheet GetStockSheetById(int id);
}
