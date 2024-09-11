using GlassCutting.Core.DTOs;
using GlassCutting.Core.Entities;

namespace GlassCuttingOptimizer.Web.Services;

public class ApiService(HttpClient httpClient)
{
    public async Task<List<StockSheet>> GetAllStockSheetsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<StockSheet>>("api/StockSheet");
    }

    public async Task<OptimizationResultDTO> OptimizeCuttingAsync()
    {
        var response = await httpClient.PostAsync("api/Optimization/optimize", null);
        return await response.Content.ReadFromJsonAsync<OptimizationResultDTO>();
    }
}
