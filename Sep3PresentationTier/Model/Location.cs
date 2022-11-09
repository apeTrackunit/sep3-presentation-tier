namespace Model;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public byte Size { get; set; }

    public Location(double latitude, double longitude, byte size)
    {
        Latitude = latitude;
        Longitude = longitude;
        Size = size;
    }
}