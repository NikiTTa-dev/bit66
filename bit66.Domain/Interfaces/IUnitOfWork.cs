using bit66.Domain.Interfaces.Repository;

namespace bit66.Domain.Interfaces;

public interface IUnitOfWork: IDisposable
{
    ISoccerRepository Players { get; }
    
    ICountryRepository Countries { get; }
    
    ICommandRepository Commands { get; }
    
    Task SaveChanges();
}