using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Entities;
public class CutLayout
{
    public int Id { get; set; }
    public int StockSheetId { get; set; }
    public List<CutPosition> CutPositions { get; set; } = new List<CutPosition>();
    public double WastePercentage { get; set; }
}
