namespace Services.Interfaces;

using Model;

public interface IEventService
{
    Task<bool> CreateAsync(Event cleaningEvent);
}