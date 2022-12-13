namespace Model.DTOs;

public class EventOverviewDto
{
    public String Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public String Description { get; set; }
    public Location Location { get; set; }
    public String OrganiserName { get; set; }

    public EventOverviewDto()
    {
    }

    public EventOverviewDto(string id, int[] date, int[] time, string description, Location location, string organiserName)
    {
        Id = id;
        Date = date;
        Time = time;
        Description = description;
        Location = location;
        OrganiserName = organiserName;
    }
}