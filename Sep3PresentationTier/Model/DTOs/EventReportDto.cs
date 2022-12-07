namespace Model.DTOs;

public class EventReportDto
{
    public byte[]? Proof { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }

    public EventReportDto(byte[]? proof, string description, Location location)
    {
        Proof = proof;
        Description = description;
        Location = location;
    }
}