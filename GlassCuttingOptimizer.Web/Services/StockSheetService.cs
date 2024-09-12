using GlassCutting.Core.Entities;

namespace GlassCuttingOptimizer.Web.Services;

public class StockSheetService(HttpClient httpClient)
{
    public async Task AddStockSheetAsync(StockSheet stockSheet)
    {
        var response = await httpClient.PostAsJsonAsync("api/StockSheet", stockSheet);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<StockSheet>> GetAllStockSheetsAsync()
    {
        var response = await httpClient.GetAsync("api/StockSheet");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<StockSheet>>();
    }

    public async Task<StockSheet> GetStockSheetByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"api/StockSheet/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StockSheet>();
    }
}
