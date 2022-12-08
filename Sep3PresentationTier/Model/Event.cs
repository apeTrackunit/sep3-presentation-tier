
namespace Model;

public class Event
{
    public string Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public byte[]? Validation { get; set; }
    public string Organiser { get; set; }
    public Report ReportRef { get; set; }

    public Event(){}

    public Event(string id, int[] date, int[] time, string description, string status, byte[]? validation, string organiser, Report reportRef)
    {
        Id = id;
        Date = date;
        Time = time;
        Description = description;
        Status = status;
        Validation = validation;
        Organiser = organiser;
        ReportRef = reportRef;
    }
}