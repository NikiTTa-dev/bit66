using bit66.Dal;
using bit66.Domain.Entities;

namespace bit66.App;

public static class MockData
{
    public static void MockDatabase(SoccerDbContext dbContext)
    {
        dbContext.Countries.AddRange(new List<Country>
        {
            new() { Id = 1, Name = "USA" },
            new() { Id = 2, Name = "Italy" },
            new() { Id = 3, Name = "Russia" }
        });

        dbContext.Commands.AddRange(new List<Command>
        {
            new() { Id = 1, Name = "NA'VI" },
            new() { Id = 2, Name = "Outsiders" }
        });
        dbContext.SaveChanges();

        dbContext.Players.AddRange(new List<SoccerPlayer>
        {
            new() { Id = 1,
                FirstName = "Данил",
                LastName = "Ишутин",
                BirthDate = DateTime.Parse("30.12.1989"),
                Gender = "Мужской",
                Command = dbContext.Commands.FirstOrDefault(c=>c.Id==1)!,
                Country = dbContext.Countries.FirstOrDefault(c=>c.Id==3)!
            },
            new() { Id = 2,
                FirstName = "Ярослав",
                LastName = "Кузнецов",
                BirthDate = DateTime.Parse("24.09.1988"),
                Gender = "Мужской",
                Command = dbContext.Commands.FirstOrDefault(c=>c.Id==2)!,
                Country = dbContext.Countries.FirstOrDefault(c=>c.Id==3)!
            }
        });

        dbContext.SaveChanges();
    }
}