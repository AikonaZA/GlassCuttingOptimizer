using GlassCutting.Core.DTOs;
using GlassCutting.Core.Entities;

namespace GlassCuttingOptimizer.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StockSheet>> GetAllStockSheetsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<StockSheet>>("api/StockSheet");
    }

    public async Task<OptimizationResultDTO> OptimizeCuttingAsync()
    {
        var response = await _httpClient.PostAsync("api/Optimization/optimize", null);
        return await response.Content.ReadFromJsonAsync<OptimizationResultDTO>();
    }
}
