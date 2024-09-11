using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptimizationController(ICuttingOptimizer cuttingOptimizer, IStockSheetRepository stockSheetRepository, IGlassPanelRepository glassPanelRepository) : ControllerBase
{
    [HttpPost("optimize")]
    public IActionResult OptimizeCutting()
    {
        var stockSheets = (IEnumerable<StockSheet>)stockSheetRepository.GetAllStockSheetsAsync();
        var glassPanels = (IEnumerable<GlassPanel>)glassPanelRepository.GetAllGlassPanelsAsync();

        var result = cuttingOptimizer.Optimize(glassPanels, stockSheets);

        return result == null ? BadRequest("Optimization failed.") : Ok(result);
    }
}
