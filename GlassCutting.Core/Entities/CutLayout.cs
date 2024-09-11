namespace GlassCutting.Core.Entities;

public class CutLayout
{
    public int Id { get; set; }
    public int StockSheetId { get; set; }
    public List<CutPosition> CutPositions { get; set; } = [];

    /// <summary>
    /// Calculated waste percentage after optimization
    /// </summary>
    public double WastePercentage { get; set; }
}