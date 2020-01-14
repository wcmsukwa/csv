using Microsoft.VisualStudio.TestTools.UnitTesting;
using csv; 
using System;
using System.Collections.Generic;
using System.Text;

namespace csv.Tests
{
    [TestClass()]
    public class readcsvTests
    {
        [TestMethod()]
        public void ReadAllRecordsInCSVTest()
        {
            var absolutePath = "c://csvfiles//worldcities.csv";
            List<City> result = readcsv.ReadAllRecordsInCSV(absolutePath);
            Assert.AreEqual(15493, result.Count);
        }

        [TestMethod()]
        public void ReadOneRecordInCSVTest()
        {
            var absolutePath = "c://csvfiles//worldcities.csv";
            List<City> result = readcsv.ReadOneRecordInCSV(absolutePath);
            Assert.AreEqual(15493, result.Count);
        }
    }
}