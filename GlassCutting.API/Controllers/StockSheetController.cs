using GlassCutting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockSheetController(IStockSheetRepository stockSheetRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStockSheets()
    {
        var stockSheets = stockSheetRepository.GetAllStockSheets();
        return Ok(stockSheets);
    }

    [HttpGet("{id}")]
    public IActionResult GetStockSheetById(int id)
    {
        var stockSheet = stockSheetRepository.GetStockSheetById(id);
        return stockSheet == null ? NotFound() : Ok(stockSheet);
    }
}
