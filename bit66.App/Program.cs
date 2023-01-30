using bit66.Dal;
using bit66.Domain.Entities;
using bit66.Domain.Enums;
using bit66.Domain.Interfaces;
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

app.Map("/new", async context =>
{
    var dbContext = context.RequestServices.GetRequiredService<SoccerDbContext>();
    //dbContext.Database.EnsureDeleted();
    //dbContext.Database.EnsureCreated();
    var unitOfWork = context.RequestServices.GetRequiredService<IUnitOfWork>();
    var mockPlayer = new SoccerPlayer
    {
        FirstName = "Alex",
        LastName = "McDonald",
        BirthDate = DateOnly.FromDateTime(DateTime.Now.AddHours(-1)),
        Command = new Command
        {
            Name = "Hello"
        },
        Country = new Country
        {
            Name = CountryNames.Russia
        }
    };
    await unitOfWork.Players.AddAsync(mockPlayer);
    await unitOfWork.SaveChanges();
    var player = (await unitOfWork.Players.GetAllAsync()).FirstOrDefault();
    await context.Response.WriteAsync(JsonConvert.SerializeObject(player));
});
app.MapRazorPages();

app.Run();