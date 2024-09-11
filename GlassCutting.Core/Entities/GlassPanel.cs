namespace GlassCutting.Core.Entities;
public class GlassPanel
{
    public int Id { get; set; }
    /// <summary>
    /// Width of the glass panel
    /// </summary>
    public double Width { get; set; }
    /// <summary>
    /// Height of the glass panel
    /// </summary>
    public double Height { get; set; }
    /// <summary>
    /// Number of panels needed
    /// </summary>
    public int Quantity { get; set; }
}
