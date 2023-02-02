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

app.Map("/new", async context =>
{
    var dbContext = context.RequestServices.GetRequiredService<SoccerDbContext>();
    //dbContext.Database.EnsureDeleted();
    //dbContext.Database.EnsureCreated();
    var unitOfWork = context.RequestServices.GetRequiredService<IUnitOfWork>();
    var mockPlayerModel = new SoccerPlayerModel
    {
        Id = 1,
        FirstName = "Aleeexx",
        LastName = "McDoaldxx",
        BirthDate = DateTime.UtcNow.AddDays(-1),
        Command = new CommandModel
        {
            Id=3,
            Name = "Hellojj"
        },
        Country = new CountryModel
        {
            Id=3,
            Name = CountryNames.Usa
        }
    };
    
    var service = context.RequestServices.GetRequiredService<ISoccerPlayerService>();

    await service.EditPlayerAsync(mockPlayerModel);
    // var mockPlayer = new SoccerPlayer
    // {
    //     Id=1,
    //     FirstName = "Alexx",
    //     LastName = "McDonaldxx",
    //     BirthDate = DateTime.UtcNow.AddDays(-1),
    //     Command = new Command
    //     {
    //         Name = "Hellox"
    //     },
    //     Country = new Country
    //     {
    //         Name = CountryNames.Italy
    //     }
    // };
    // var mockPlayer2 = await unitOfWork.Players.FindAsync(1);
    // await unitOfWork.Players.DeleteAsync(2);
    // await unitOfWork.SaveChanges();
    var player = (await unitOfWork.Players.GetAllPlayersWithCountryAndCommandAsync()).FirstOrDefault();
    await context.Response.WriteAsync(JsonConvert.SerializeObject(player));
});
app.MapRazorPages();

app.Run();