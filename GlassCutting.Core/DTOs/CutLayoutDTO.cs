namespace GlassCutting.Core.DTOs;
public class CutLayoutDTO
{
    public int StockSheetId { get; set; }
    public List<CutPositionDTO> CutPositions { get; set; }
    public double WastePercentage { get; set; }
}

