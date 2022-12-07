using Model;

namespace Services.Interfaces;

public interface IEventService
{
    Task<ICollection<Event>> GetAsync();
}