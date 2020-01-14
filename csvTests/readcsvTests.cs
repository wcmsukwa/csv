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
        public void MainTest()
        {
            csv.readcsv.Main();
            Assert.Fail();
        }
    }

    public class ReadcsvTests
    {
        [TestMethod()]
        public void ReadCSVTest()
        {
            csv.readcsv.Main();
            Assert.Fail();
        }
    }
}