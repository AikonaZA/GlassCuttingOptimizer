using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;
public interface IGlassPanelRepository
{
    IEnumerable<GlassPanel> GetAllGlassPanels();
    GlassPanel GetGlassPanelById(int id);
}
