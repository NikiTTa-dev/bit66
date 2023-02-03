using bit66.Dal;
using bit66.Domain.Entities;
using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;
using bit66.Logic;
using Newtonsoft.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddRazorPages()
    .AddNewtonsoftJson();

builder.Services
    .AddDal(builder.Configuration.GetConnectionString("sqlite")!)
    .AddLogic();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Map("/new", (HttpContext context) => 
{
    var dbContext = context.RequestServices.GetRequiredService<SoccerDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
});
app.MapRazorPages();

app.Run();