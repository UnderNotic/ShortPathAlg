using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ShorterPathAlg.Models;

namespace ShorterPathAlg.Providers
{
    public interface ICsvFileReader
    {
        IEnumerable<CsvLocation> GetLocations(string pathToFile);
    }

    public class CsvFileReader : ICsvFileReader
    {
        private IList<CsvLocation> _parsedLocations = new List<CsvLocation>();
        private IList<string> _parsedLine = new List<string>();

        public CsvFileReader()
        {
        }

        public IEnumerable<CsvLocation> GetLocations(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile).Skip(1).Select(s => s.Split(',')).ToList();

            try
            {
                foreach (var line in lines)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i].StartsWith("\""))
                        {
                            var k = i;
                            do
                            {
                                ++i;
                            } while (!line[i].EndsWith("\""));

                            StringBuilder toAdd = new StringBuilder();
                            for (;k <= i; k++)
                            {
                                toAdd.Append(line[k]);
                            }

                            _parsedLine.Add(toAdd.ToString());
                        }
                        else
                        {
                            _parsedLine.Add(line[i]);
                        }
                    }

                    _parsedLocations.Add(new CsvLocation(int.Parse(_parsedLine[0]))
                    {
                        Name = _parsedLine[1],
                        Brand = _parsedLine[2],
                        StoreNumber = _parsedLine[3],
                        PhoneNumber = _parsedLine[4],
                        OwnershipType = _parsedLine[5],
                        StreetCombined = _parsedLine[6],
                        Street1 = _parsedLine[7],
                        Street2 = _parsedLine[8],
                        Street3 = _parsedLine[9],
                        City = _parsedLine[10],
                        CountrySubdivision = _parsedLine[11],
                        Country = _parsedLine[12],
                        PostalCode = _parsedLine[13],
                        Coordinates = _parsedLine[14],
                        Latitude = double.Parse(_parsedLine[15]),
                        Longitude = double.Parse(_parsedLine[16]),
                        Timezone = _parsedLine[17],
                        CurrentTimezoneOffset = int.Parse(_parsedLine[18]),
                        OlsonTimezone = _parsedLine[19]
                    });

                    _parsedLine.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Specified file is not in the correct format " + ex.Message);
            }



            return _parsedLocations;


        }
    }
}