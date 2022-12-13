using Model.DTOs;

namespace Model;

public class Event
{
    public string Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public string Description { get; set; }

    public byte[]? Validation { get; set; }
    public UserDto Organiser { get; set; }
    public Report Report { get; set; }
    public bool Approved { get; set; }
    public ICollection<User> Attendees { get; set; }

    public Event(){}

    public Event(string id, int[] date, int[] time, string description, byte[]? validation, UserDto organiser, Report report, bool approved, ICollection<User> attendees)
    {
        Id = id;
        Date = date;
        Time = time;
        Description = description;
        Validation = validation;
        Organiser = organiser;
        Report = report;
        Approved = approved;
        Attendees = attendees;
    }
}