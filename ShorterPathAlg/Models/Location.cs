namespace ShorterPathAlg.Models
{
    public class Location : ConnectableLocation<Location>
    {
        public Location(int id, double latitude, double longitude)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}