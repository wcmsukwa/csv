using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.Generic;
using System.IO;

namespace csv
{
    public class readcsv
    {
        public static void Main()
        {
            var path = "c://csvfiles//worldcities.csv";
            var recordList = ReadInCSV(path);
        }

        public static List<City> ReadInCSV(string absolutePath)
        {
            List<City> result = new List<City>();
            using (var reader = new StreamReader(absolutePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(double), new EmptyDouble());
                    csv.Configuration.RegisterClassMap<CityMap>();
                    //csv.Configuration.RegisterClassMap<CityMap>;

                    while (csv.Read())
                    {
                        result.Add(csv.GetRecord<City>());
                    }
                }
                return result;
            }
        }
    }

    public class City
    {
        public string city { get; set; }
        public string city_ascii { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public double population { get; set; }
        public float id { get; set; }
    }

    public sealed class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            AutoMap();
        }
    }
    public class EmptyDouble : DoubleConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "")
            {
                double value = 0;
                return value;
            } else
            {
                double value = System.Convert.ToDouble(text);
                return value;
            }
        }
    }
}