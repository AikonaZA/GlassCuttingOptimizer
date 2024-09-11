using GlassCutting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptimizationController : ControllerBase
{
    private readonly ICuttingOptimizer _cuttingOptimizer;
    private readonly IStockSheetRepository _stockSheetRepository;
    private readonly IGlassPanelRepository _glassPanelRepository;

    public OptimizationController(ICuttingOptimizer cuttingOptimizer,
                                  IStockSheetRepository stockSheetRepository,
                                  IGlassPanelRepository glassPanelRepository)
    {
        _cuttingOptimizer = cuttingOptimizer;
        _stockSheetRepository = stockSheetRepository;
        _glassPanelRepository = glassPanelRepository;
    }

    [HttpPost("optimize")]
    public IActionResult OptimizeCutting()
    {
        var stockSheets = _stockSheetRepository.GetAllStockSheets();
        var glassPanels = _glassPanelRepository.GetAllGlassPanels();

        var result = _cuttingOptimizer.Optimize(glassPanels, stockSheets);

        if (result == null)
        {
            return BadRequest("Optimization failed.");
        }

        return Ok(result);
    }
}
