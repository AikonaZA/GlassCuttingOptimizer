using GlassCutting.Application.Interfaces;
using GlassCutting.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlassCutting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlassPanelController(IGlassPanelService glassPanelService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddGlassPanel([FromBody] GlassPanel glassPanel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await glassPanelService.AddGlassPanelAsync(glassPanel);
        return Ok(glassPanel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGlassPanels()
    {
        var glassPanels = await glassPanelService.GetAllGlassPanelsAsync();
        return Ok(glassPanels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGlassPanelById(int id)
    {
        var glassPanel = await glassPanelService.GetGlassPanelByIdAsync(id);
        return glassPanel == null ? NotFound() : Ok(glassPanel);
    }
}
