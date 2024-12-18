using CoffeeShopWEBAPI.Data;
using FluentValidation.AspNetCore;
using System.Reflection; 
// chnage
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<CityRepository>(); // change
builder.Services.AddScoped<StateRepository>(); // change
builder.Services.AddScoped<CountryRepository>(); //change


builder.Services.AddSwaggerGen();

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

app.Run();
