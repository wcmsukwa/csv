using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace Csv
{
    public class ReadCsv
    {
        public static IList<T> ReadCsvFile<T, M>(string absolutePath, CsvHelper.TypeConversion.ITypeConverter DoubleTypeConversion)
        {
            Type mapType = typeof(M);
            IList<T> results = new List<T>();
            using var reader = new StreamReader(absolutePath);
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.TypeConverterCache.AddConverter(typeof(double), DoubleTypeConversion);
                csv.Configuration.RegisterClassMap(mapType);

                while (csv.Read())
                {
                    results.Add(csv.GetRecord<T>());
                }
            }
            return results;
        }
    }
}