namespace Model.DTOs;

public class LocationDto
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int size { get; set; }

    public LocationDto(Location loc)
    {
        this.latitude = loc.Latitude;
        this.longitude = loc.Longitude;
        this.size = loc.Size;
    }
}