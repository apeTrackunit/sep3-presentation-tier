namespace Model.DTOs;

public class CreateEventDto
{
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public string Description { get; set; }
    public string ReportId { get; set; }
    
    public CreateEventDto(){}

    public CreateEventDto(int[] date, int[] time, string description, string reportId)
    {
        Date = date;
        Time = time;
        Description = description;
        ReportId = reportId;
    }
}