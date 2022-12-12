namespace Model.DTOs;

public class EventDto
{
    public string Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public string Description { get; set; }

    public byte[]? Validation { get; set; }
    public string OrganiserId { get; set; }
    public string Username { get; set; }
    public EventReportDto Report { get; set; }
    public bool Approved { get; set; }
}