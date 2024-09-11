using GlassCutting.Application.Interfaces;
using GlassCutting.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockSheetController(IStockSheetService stockSheetService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddStockSheet([FromBody] StockSheet stockSheet)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await stockSheetService.AddStockSheetAsync(stockSheet);
        return Ok(stockSheet);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStockSheets()
    {
        var stockSheets = await stockSheetService.GetAllStockSheetsAsync();
        return Ok(stockSheets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStockSheetById(int id)
    {
        var stockSheet = await stockSheetService.GetStockSheetByIdAsync(id);
        return stockSheet == null ? NotFound() : Ok(stockSheet);
    }
}
