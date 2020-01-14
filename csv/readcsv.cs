using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.Generic;
using System.IO;
using Cities;

namespace csv
{
    public class readcsv
    {
        City city = new City();
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

    public sealed class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            AutoMap();
            Map(m => m.City_name).Name("city");
            Map(m => m.City_ascii).Name("city_ascii");
            Map(m => m.Admin_name).Name("admin_name");
            Map(m => m.Capital).Name("capital");
            Map(m => m.Country).Name("country");
            Map(m => m.Id).Name("id");
            Map(m => m.ISO2).Name("iso2");
            Map(m => m.ISO3).Name("iso3");
            Map(m => m.Lat).Name("lat");
            Map(m => m.Lng).Name("lng");
            Map(m => m.Population).Name("population");
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