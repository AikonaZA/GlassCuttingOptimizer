using GlassCutting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockSheetController : ControllerBase
{
    private readonly IStockSheetRepository _stockSheetRepository;

    public StockSheetController(IStockSheetRepository stockSheetRepository)
    {
        _stockSheetRepository = stockSheetRepository;
    }

    [HttpGet]
    public IActionResult GetAllStockSheets()
    {
        var stockSheets = _stockSheetRepository.GetAllStockSheets();
        return Ok(stockSheets);
    }

    [HttpGet("{id}")]
    public IActionResult GetStockSheetById(int id)
    {
        var stockSheet = _stockSheetRepository.GetStockSheetById(id);
        if (stockSheet == null)
        {
            return NotFound();
        }
        return Ok(stockSheet);
    }
}
