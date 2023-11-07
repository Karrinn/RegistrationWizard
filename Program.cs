using FastEndpoints;
using FastEndpoints.Swagger;
using RegistrationWizard.Application;
using RegistrationWizard.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddFastEndpoints()
    .AddApplication()
    .SwaggerDocument();

var application = builder.Build();

application
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseInfrastructure();

await application.SeedDatabaseAsync();
await application.RunAsync();
