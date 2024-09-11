using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Entities;
public class GlassPanel
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int Quantity { get; set; }   // Number of panels to cut
}
