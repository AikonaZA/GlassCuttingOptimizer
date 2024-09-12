using GlassCutting.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseController(IDatabaseService databaseService) : ControllerBase
{
    [HttpPost("clear")]
    public async Task<IActionResult> ClearDatabase()
    {
        await databaseService.ClearDatabaseAsync();
        return Ok("Database cleared successfully.");
    }

    [HttpPost("reset")]
    public async Task<IActionResult> ResetDatabase()
    {
        await databaseService.ResetDatabaseAsync();
        return Ok("Database reset successfully.");
    }
}
