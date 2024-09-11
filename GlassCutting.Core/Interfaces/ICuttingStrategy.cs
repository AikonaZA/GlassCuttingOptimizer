using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;

public interface ICuttingStrategy
{
    CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets);
}