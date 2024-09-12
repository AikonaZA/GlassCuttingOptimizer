using GlassCutting.Core.Entities;

namespace GlassCuttingOptimizer.Web.Services;

public class OptimizationService(HttpClient httpClient)
{
    public async Task<CutLayout> OptimizeCuttingAsync()
    {
        var response = await httpClient.PostAsync("api/Optimization/optimize", null);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CutLayout>();
    }
}
