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
        public void ReadInCSVTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            Assert.AreEqual(15493, csv.readcsv.ReadInCSV(path).Count);
        }
    }
}