using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Services;

public class CuttingOptimizerService(IStockSheetRepository stockSheetRepository, IGlassPanelRepository glassPanelRepository, ICuttingStrategy cuttingStrategy) : ICuttingOptimizer
{
    public CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        // Use the provided strategy to optimize the layout
        return cuttingStrategy.Optimize(panels, sheets);
    }
}