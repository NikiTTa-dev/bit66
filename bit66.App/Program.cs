using bit66.Dal;
using bit66.Domain.Entities;
using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Repository;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services
    .AddDal(builder.Configuration.GetConnectionString("sqlite")!);

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

app.Map("/new", async (HttpContext context) =>
{
    var repos = context.RequestServices.GetRequiredService<IRepository<SoccerPlayer>>();
    var player = await repos.FindAsync(1);
    await context.Response.WriteAsync(JsonConvert.SerializeObject(player));
});
app.MapRazorPages();

app.Run();