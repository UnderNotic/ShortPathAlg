namespace ShorterPathAlg.Models
{
    public class Location : ConnectableLocation<Location>
    {
        public Location(int id, double latitude, double longitude) : base(id)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}