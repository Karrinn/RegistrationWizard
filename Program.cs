using FastEndpoints;
using FastEndpoints.Swagger;
using RegistrationWizard.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseInfrastructure();

// await app.SeedDataAsync();
app.Run();
