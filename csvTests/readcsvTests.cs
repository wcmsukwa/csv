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
            readcsv.Main();
            Assert.Fail();
        }
    }
}