using GlassCutting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassCutting.Core.Interfaces;
public interface IStockSheetRepository
{
    IEnumerable<StockSheet> GetAllStockSheets();
    StockSheet GetStockSheetById(int id);
}
