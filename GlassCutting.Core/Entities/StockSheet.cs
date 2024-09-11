namespace GlassCutting.Core.Entities;
public class StockSheet
{
    public int Id { get; set; }
    /// <summary>
    /// Width of the stock sheet
    /// </summary>
    public double Width { get; set; }
    /// <summary>
    /// Height of the stock sheet
    /// </summary>
    public double Height { get; set; }
    /// <summary>
    /// Number of sheets available
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Represent available area
    /// </summary>
    public double AvailableArea { get; set; }

}
