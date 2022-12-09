namespace Model.DTOs;

public class CreateEventDto
{
    public int[] date { get; set; }
    public int[] time { get; set; }
    public string description { get; set; }
    public string reportId { get; set; }
    
    public CreateEventDto(){}

    public CreateEventDto(int[] date, int[] time, string description, string reportId)
    {
        this.date = date;
        this.time = time;
        this.description = description;
        this.reportId = reportId;
    }
}