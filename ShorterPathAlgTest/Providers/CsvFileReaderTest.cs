using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ShorterPathAlg.Providers;

namespace ShorterPathAlgTest.Providers
{
    [TestFixture]
    public class CsvFileReaderTest
    {
        string currPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\test.csv");
        private CsvFileReader _reader;

        [SetUp]
        public void Init()
        {
            _reader = new CsvFileReader();
            using (StreamWriter sw = File.CreateText(currPath))
            {
                sw.WriteLine("Store ID,Name,Brand,Store Number,Phone Number,Ownership Type,Street Combined,Street 1,Street 2,Street 3,City,Country Subdivision,Country,Postal Code,Coordinates,Latitude,Longitude,Timezone,Current Timezone Offset,Olson Timezone");
                sw.WriteLine("5499,Grunwaldzki Center,Starbucks,3105-129884,48713861913,JV,Plac Grunwaldzki 23,Plac Grunwaldzki 23,,,Wroclaw,DS,PL,50-365,\"(51.1127243041992, 17.0631198883057)\",51.112724304199219,17.063119888305664,Central European Standard Time,120,GMT+1:00 Europe/Warsaw");
                sw.WriteLine("5500,Zodiak,Starbucks,6200-130665,48713861687,JV,ul. Widok 26,ul. Widok 26,,,Warsaw,MZ,PL,00-023,\"(52.2309303283691, 21.0124282836914)\",52.230930328369141,21.012428283691406,Central European Standard Time,120,GMT+1:00 Europe/Warsaw");
            }
        }

        [Test]
        public void CountOfObjectIsCorrect()
        {
            var locs = _reader.GetLocations(currPath);
            Assert.AreEqual(2, locs.Count());
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(currPath);
        }
    }
}