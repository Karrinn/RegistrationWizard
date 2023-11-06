using RegistrationWizard.Entities;
using RegistrationWizard.Database;
using RegistrationWizard.Services;
using RegistrationWizard.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (ApplicationContext db = new ApplicationContext())
{
    Country russia = new() { Name = "Russia" };
    Country germany = new() { Name = "Germany" };
    Country usa = new() { Name = "USA" };
    db.Country.AddRange(russia, germany, usa);

    Province moscow = new() { Name = "Moscow", Country = russia };
    Province sp = new() { Name = "Saint Petersburg", Country = russia };
    db.Province.AddRange(moscow, sp);

    Province berlin = new() { Name = "Berlin", Country = germany };
    Province hamburg = new() { Name = "Hamburg", Country = germany };
    db.Province.AddRange(berlin, hamburg);

    Province newYork = new() { Name = "New York", Country = usa };
    Province washingtonDC = new() { Name = "Washington, D.C.", Country = usa };
    db.Province.AddRange(newYork, washingtonDC);

    db.SaveChanges();
}

app.Run();
