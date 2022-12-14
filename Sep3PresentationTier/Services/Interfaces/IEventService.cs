using Model.DTOs;

namespace Services.Interfaces;

using Model;

public interface IEventService
{
    Task<ICollection<EventOverviewDto>> GetAsync(string filter);
    Task<bool> CreateAsync(Event cleaningEvent);
    Task<bool> ApproveEvent(string id, bool approved);
    Task<Event> GetEvent(string id);
    Task<bool> AttendEvent(string eventId);
    Task<bool> ValidateEvent(string eventId, byte[] validation);
}