using GlassCutting.Core.Entities;

namespace GlassCuttingOptimizer.Web.Services;

public class GlassPanelService(HttpClient httpClient)
{
    public async Task AddGlassPanelAsync(GlassPanel glassPanel)
    {
        var response = await httpClient.PostAsJsonAsync("api/GlassPanel", glassPanel);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<GlassPanel>> GetAllGlassPanelsAsync()
    {
        var response = await httpClient.GetAsync("api/GlassPanel");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<GlassPanel>>();
    }
}
