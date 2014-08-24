using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SorterFs;

namespace FSharpLib.Test
{
    [TestClass]
    public class SwitchFixture
    {
        [TestMethod]
        public void TestSwitchesForValidity()
        {

            Assert.IsTrue(SwitchFunctions.IsValid(new Switch(0, 1)));
            Assert.IsTrue(SwitchFunctions.IsValid(new Switch(10, 11)));
            Assert.IsFalse(SwitchFunctions.IsValid(new Switch(1, 1)));
            Assert.IsFalse(SwitchFunctions.IsValid(new Switch(0, -1)));
            Assert.IsFalse(SwitchFunctions.IsValid(new Switch(-1, 1)));
            Assert.IsFalse(SwitchFunctions.IsValid(new Switch(3, 1)));
        }

        [TestMethod]
        public void TestBitonicCount()
        {

            var res = BitonicFunctions.BitonicSwitchCount(7);
        }


        [TestMethod]
        public void TestSpanner()
        {

            var res = SwitchFunctions.Spanner(4);

            res = SwitchFunctions.Spanner(3);

            res = SwitchFunctions.Spanner(5);

            res = SwitchFunctions.Spanner(16);

        }


        [TestMethod]
        public void TestAppendSwitches()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            };

            var appended = SwitchFunctions.AppendBelow(testSwitches, 4);

        }

        [TestMethod]
        public void TestBitonicSwitches()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            };

            var appended = BitonicFunctions.BitonicSwitches(3);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(appended));
        }

    }
}
