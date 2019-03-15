using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Debug.WriteLine($"TestInitialize {DateTime.Now}");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Debug.WriteLine($"TestCleanUp {DateTime.Now}");
        }

        [TestMethod]
        public void Adding_12_3()
        {
            int a = 1;
            int b = 2;

            int result = 3;

            int act_res = Sample.Program.Adding(a, b);

            Assert.AreEqual(result, act_res);
        }

        [TestMethod]
        public void Subtracting_54_1()
        {
            int a = 5;
            int b = 4;

            int res = 1;

            int act_res = Sample.Program.Subtracting(a, b);

            Assert.AreEqual(res, act_res);
        }
    }
}
