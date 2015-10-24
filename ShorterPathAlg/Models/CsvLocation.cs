namespace ShorterPathAlg.Models
{
    public class CsvLocation
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string StoreNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnershipType { get; set; }
        public string StreetCombined { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string CountrySubdivision { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Coordinates { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public int CurrentTimezoneOffset { get; set; }
        public string OlsonTimezone { get; set; }

        public Location ToBasicLocation()
        {
            return new Location()
            {
                StoreId = StoreId,
                Pos1 = Latitude,
                Pos2 = Longitude
            };
        }
    }
}