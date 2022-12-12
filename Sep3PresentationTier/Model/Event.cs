namespace Model;

public class Event
{
    public string Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public string Description { get; set; }

    public byte[]? Validation { get; set; }
    public string Organiser { get; set; }
    public Report Report { get; set; }
    public bool Approved { get; set; }

    public Event(){}

    public Event(string id, int[] date, int[] time, string description, byte[]? validation, string organiser, Report report, bool approved)
    {
        Id = id;
        Date = date;
        Time = time;
        Description = description;
        Validation = validation;
        Organiser = organiser;
        Report = report;
        Approved = approved;
    }
}