var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GlassCuttingOptimizer_Web>("webfrontend")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.GlassCutting_API>("glasscutting-api");

builder.Build().Run();