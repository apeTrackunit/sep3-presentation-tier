namespace Model;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Size { get; set; }

    public Location(double latitude, double longitude, int size)
    {
        Latitude = latitude;
        Longitude = longitude;
        Size = size;
    }

    public Location(int size)
    {
        Size = size;
    }

    public Location()
    {
    }
}