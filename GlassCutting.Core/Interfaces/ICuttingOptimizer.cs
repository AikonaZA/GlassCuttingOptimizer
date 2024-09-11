using GlassCutting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Interfaces;
public interface ICuttingOptimizer
{
    CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets);
}
