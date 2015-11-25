namespace ShorterPathAlg.Models
{
    public class Location : ConnectableLocation<Location>
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Location(string id, double latitude, double longitude) : base(id)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}