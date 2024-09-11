using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Entities;
public class StockSheet
{
    public int Id { get; set; }
    public double Width { get; set; }   // e.g., 2440mm
    public double Height { get; set; }  // e.g., 3660mm
    public int Quantity { get; set; }   // Number of sheets available
}
