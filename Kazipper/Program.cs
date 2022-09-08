using Kazipper.Configuration;
using Kazipper.Data;
using Kazipper.Data.Repositories;
using Kazipper.Data.Repositories.Implementation;
using Kazipper.Handlers;
using Kazipper.Services;
using Kazipper.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var settings = configuration.GetSection("AppSettings").Get<Settings>();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseInMemoryDatabase("kazipper");
});
builder.Services.AddTransient(_=> settings);
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IOpenWeatherHelper, OpenWeatherHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin();
    policyBuilder.AllowAnyMethod();
});
app.Run();

