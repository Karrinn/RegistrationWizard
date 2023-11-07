using FastEndpoints;
using FastEndpoints.Swagger;
using RegistrationWizard.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddFastEndpoints()
    .SwaggerDocument();

var application = builder.Build();

application
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseInfrastructure();

await application.SeedDatabaseAsync();
await application.RunAsync();
