using GlassCutting.Core.Entities;

namespace GlassCutting.Application.Interfaces;

public interface IGlassPanelService
{
    Task<IEnumerable<GlassPanel>> GetAllGlassPanelsAsync();
    Task AddGlassPanelAsync(GlassPanel glassPanel);
    Task<GlassPanel> GetGlassPanelByIdAsync(int id);
}
