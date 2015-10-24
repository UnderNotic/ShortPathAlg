using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Providers
{
    public class CsvFileReader
    {
        private string _pathToFile = Directory.GetCurrentDirectory();

        public CsvFileReader()
        {
            
        }

        public IEnumerable<CsvLocation> GetLocations()
        {
           return
                File.ReadAllLines(_pathToFile).Skip(1).Select(s => s.Split(',')).Select(strings => new CsvLocation()
                {
                    StoreId = int.Parse(strings[0]),
                    Name = strings[1],
                    Brand = strings[1],
                    StoreNumber = strings[2],
                    PhoneNumber = strings[3],
                    OwnershipType = strings[4],
                    StreetCombined = strings[5],
                    Street1 = strings[6],
                    Street2 = strings[7],
                    Street3 = strings[8],
                    City = strings[9],
                    CountrySubdivision = strings[10],
                    Country = strings[11],
                    PostalCode = strings[12],
                    Coordinates = strings[13],
                    Latitude = double.Parse(strings[14]),
                    Longitude = double.Parse(strings[15]),
                    Timezone = strings[16],
                    CurrentTimezoneOffset = int.Parse(strings[17]),
                    OlsonTimezone = strings[18]
                });
        }


    }
}