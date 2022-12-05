namespace Model;

public class Report
{
    public string Id { get; set; }
    public int[] Date { get; set; }
    public int[] Time { get; set; }
    public byte[]? Proof { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    
    public Location Location { get; set; }

    public Report()
    {
        
    }

    public Report(string id, int[] date, int[] time, byte[]? proof, string description, string status, Location location)
    {
        Id = id;
        Date = date;
        Time = time;
        Proof = proof;
        Description = description;
        Status = status;
        Location = location;
    }
}