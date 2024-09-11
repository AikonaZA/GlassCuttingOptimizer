using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;

namespace GlassCutting.Infrastructure.Repositories;
public class GlassPanelRepository(ApplicationDbContext context) : IGlassPanelRepository
{
    public IEnumerable<GlassPanel> GetAllGlassPanels()
    {
        return [.. context.GlassPanels];
    }

    public GlassPanel GetGlassPanelById(int id)
    {
        return context.GlassPanels.Find(id);
    }
}
