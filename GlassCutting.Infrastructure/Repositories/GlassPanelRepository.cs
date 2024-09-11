using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Infrastructure.Repositories;
public class GlassPanelRepository : IGlassPanelRepository
{
    private readonly ApplicationDbContext _context;

    public GlassPanelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<GlassPanel> GetAllGlassPanels()
    {
        return _context.GlassPanels.ToList();
    }

    public GlassPanel GetGlassPanelById(int id)
    {
        return _context.GlassPanels.Find(id);
    }
}
