using GlassCutting.Core.Entities;

namespace GlassCutting.Core.Interfaces;

public interface IGlassPanelRepository
{
    Task AddGlassPanelAsync(GlassPanel glassPanel);

    Task<IEnumerable<GlassPanel>> GetAllGlassPanelsAsync();

    Task<GlassPanel> GetGlassPanelByIdAsync(int id);
}