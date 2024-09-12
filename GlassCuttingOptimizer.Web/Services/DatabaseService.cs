namespace GlassCuttingOptimizer.Web.Services;

public class DatabaseService(HttpClient httpClient)
{
    public async Task ClearDatabaseAsync()
    {
        var response = await httpClient.PostAsync("api/Database/clear", null);
        response.EnsureSuccessStatusCode();
    }

    public async Task ResetDatabaseAsync()
    {
        var response = await httpClient.PostAsync("api/Database/reset", null);
        response.EnsureSuccessStatusCode();
    }
}
