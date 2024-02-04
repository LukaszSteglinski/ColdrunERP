using ColdrunERP.Business.Services;
using ColdrunERP.Business.Services.Interfaces;
using ColdrunERP.Data.Contexts;
using ColdrunERP.Data.Repositories;
using ColdrunERP.Data.Repositories.Interfaces;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TruckDbContext>();

builder.Services.AddTransient<ITruckRepository, TruckRepository>();
builder.Services.AddTransient<ITruckService, TruckService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<TruckDbContext>();
        dbContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
