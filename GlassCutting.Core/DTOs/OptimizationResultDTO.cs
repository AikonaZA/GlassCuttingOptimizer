namespace GlassCutting.Core.DTOs;

public class OptimizationResultDTO
{
    public int StockSheetId { get; set; }
    public List<CutPositionDTO> CutPositions { get; set; }
    public double WastePercentage { get; set; }
}

