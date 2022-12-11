namespace Services.Interfaces;

using Model;

public interface IEventService
{
    Task<ICollection<Event>> GetAsync();
    Task<bool> CreateAsync(Event cleaningEvent);
    Task<bool> ApproveEvent(string id, bool approved);
    Task<Event> GetEvent(string id);
}