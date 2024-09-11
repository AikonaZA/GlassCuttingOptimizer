using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;
public interface ICuttingOptimizer
{
    CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets);
}
