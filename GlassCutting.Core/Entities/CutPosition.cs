namespace GlassCutting.Core.Entities;

public class CutPosition
{
    public int Id { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int CutLayoutId { get; set; }
}