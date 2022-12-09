namespace Model;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Size { get; set; }

    public Location()
    {
    }
    public Location(int size)
    {
        this.Size = size;
    }
    public Location(double latitude, double longitude, int size)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Size = size;
    }
}