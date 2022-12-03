namespace Model.DTOs;

public class CreateReportDto
{
    public int[] date { get; set; }
    public int[] time { get; set; }
    public byte[]? proof { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    
    public Location location { get; set; }

    public CreateReportDto()
    {
    }

    public CreateReportDto(int[] date, int[] time, byte[]? proof, string description, string status, Location location)
    {
        this.date = date;
        this.time = time;
        this.proof = proof;
        this.description = description;
        this.status = status;
        this.location = location;
    }
}