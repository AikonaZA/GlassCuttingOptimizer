using GlassCutting.Application.Interfaces;
using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Services;

public class GlassPanelService(IGlassPanelRepository glassPanelRepository) : IGlassPanelService
{
    public async Task<IEnumerable<GlassPanel>> GetAllGlassPanelsAsync()
    {
        return await glassPanelRepository.GetAllGlassPanelsAsync();
    }

    public async Task AddGlassPanelAsync(GlassPanel glassPanel)
    {
        await glassPanelRepository.AddGlassPanelAsync(glassPanel);
    }

    public async Task<GlassPanel> GetGlassPanelByIdAsync(int id)
    {
        return await glassPanelRepository.GetGlassPanelByIdAsync(id);
    }
}
