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
        var stockSheets = stockSheetRepository.GetAllStockSheets();
        var glassPanels = glassPanelRepository.GetAllGlassPanels();

        var result = cuttingOptimizer.Optimize(glassPanels, stockSheets);

        return result == null ? BadRequest("Optimization failed.") : Ok(result);
    }
}
