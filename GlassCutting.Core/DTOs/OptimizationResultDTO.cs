using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.DTOs;

public class OptimizationResultDTO
{
    public int StockSheetId { get; set; }
    public List<CutPositionDTO> CutPositions { get; set; }
    public double WastePercentage { get; set; }
}

