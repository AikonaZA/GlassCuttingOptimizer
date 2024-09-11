using GlassCutting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Interfaces;
public interface IGlassPanelRepository
{
    IEnumerable<GlassPanel> GetAllGlassPanels();
    GlassPanel GetGlassPanelById(int id);
}
