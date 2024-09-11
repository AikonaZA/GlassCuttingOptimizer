using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using GlassCutting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Infrastructure.Repositories;
public class StockSheetRepository : IStockSheetRepository
{
    private readonly ApplicationDbContext _context;

    public StockSheetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<StockSheet> GetAllStockSheets()
    {
        return _context.StockSheets.ToList();
    }

    public StockSheet GetStockSheetById(int id)
    {
        return _context.StockSheets.Find(id);
    }
}
