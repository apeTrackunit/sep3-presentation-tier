namespace Model;

public class Location
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int size { get; set; }

    public Location(double latitude, double longitude, int size)
    {
        latitude = latitude;
        longitude = longitude;
        size = size;
    }

    public Location(int size)
    {
        size = size;
    }

    public Location()
    {
    }
}