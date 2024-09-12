using GlassCutting.Core.Configuration;
using GlassCuttingOptimizer.ServiceDefaults;
using GlassCuttingOptimizer.Web.Components;
using GlassCuttingOptimizer.Web.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Configure a named HttpClient with BaseUrl from ApiSettings
builder.Services.AddHttpClient("ApiHttpClient", (sp, client) =>
{
    var apiSettings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(apiSettings.BaseUrl);
});

// Register Services and inject the named HttpClient
builder.Services.AddScoped(sp =>
    new GlassPanelService(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiHttpClient")));

builder.Services.AddScoped(sp =>
    new StockSheetService(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiHttpClient")));

builder.Services.AddScoped(sp =>
    new DatabaseService(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiHttpClient")));

builder.Services.AddScoped(sp =>
    new OptimizationService(sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiHttpClient")));

// Add Razor Components and Interactive Server Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
