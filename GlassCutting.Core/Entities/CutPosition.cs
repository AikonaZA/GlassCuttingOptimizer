namespace GlassCutting.Core.Entities;

public class CutPosition
{
    public int Id { get; set; }

    /// <summary>
    /// X-coordinate of the panel's top-left corner
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y-coordinate of the panel's top-left corner
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Width of the panel
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Height of the panel
    /// </summary>
    public double Height { get; set; }

    public int CutLayoutId { get; set; }
}