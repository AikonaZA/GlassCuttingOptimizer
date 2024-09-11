using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GlassCutting.Infrastructure.Repositories;

public class GlassPanelRepository(ApplicationDbContext context) : IGlassPanelRepository
{
    public async Task<IEnumerable<GlassPanel>> GetAllGlassPanelsAsync()
    {
        return await context.GlassPanels.ToListAsync();
    }

    public async Task<GlassPanel> GetGlassPanelByIdAsync(int id)
    {
        return await context.GlassPanels.FindAsync(id);
    }

    public async Task AddGlassPanelAsync(GlassPanel glassPanel)
    {
        await context.GlassPanels.AddAsync(glassPanel);
        await context.SaveChangesAsync();
    }
}