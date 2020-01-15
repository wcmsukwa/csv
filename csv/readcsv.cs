using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Csv
{
    public class ReadCsv
    {
        public static IList ReadCsvFile<T>(string absolutePath, object Model, object ModelMap, CsvHelper.TypeConversion.ITypeConverter DoubleTypeConversion)
        {
            Type objectType = Model.GetType();
            Type t = typeof(T);

            var listType = typeof(List<>).MakeGenericType(t);
            var results = (IList)Activator.CreateInstance(listType);
            //dynamic results = new List<T>();
            using var reader = new StreamReader(absolutePath);
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.TypeConverterCache.AddConverter(typeof(double), DoubleTypeConversion);
                Type mapType = ModelMap.GetType();
                csv.Configuration.RegisterClassMap(mapType);
                
                while (csv.Read())
                {

                    // var instantiatedObject = Activator.CreateInstance(objectType);
                    results.Add(csv.GetRecord(objectType));
                }
                
            }
            // queryResult = results.AsQueryable();
            return results;
        }
    }
}