var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.GlassCuttingOptimizer_ApiService>("apiservice");

builder.AddProject<Projects.GlassCuttingOptimizer_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.GlassCutting_API>("glasscutting-api");

builder.Build().Run();
