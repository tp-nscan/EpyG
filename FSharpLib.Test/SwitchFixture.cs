using System;
using System.Linq;
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

            var res = SwitchFunctions.SpanFolder(4);

            res = SwitchFunctions.SpanFolder(3);

            res = SwitchFunctions.SpanFolder(5);

            res = SwitchFunctions.SpanFolder(16);

        }

        [TestMethod]
        public void TestSwitchOffset()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            }.AsEnumerable();

            var res = SwitchFunctions.SwitchOffset(testSwitches, 2);
        }

        [TestMethod]
        public void TestSwitchMultiOffset()
        {
            var testSwitches = new[]
            {
                new Switch(0, 2),
                //new Switch(0, 2),
                //new Switch(0, 3)
            }.AsEnumerable();

            var res = SwitchFunctions.SwitchMultiOffset(testSwitches, 1, 2);

            var res2 = SwitchFunctions.SwitchMultiOffset(res, 4, 4);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res2));
        }

        [TestMethod]
        public void TestBitonicSuffix()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            }.AsEnumerable();

            var res = SwitchFunctions.BitonicSuffix(1);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res));
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
            var appended = BitonicFunctions.BitonicSwitches(4);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListIndexes(appended));
        }

        [TestMethod]
        public void TestPlay()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            }.AsEnumerable();

            var appended = Play.CwSeq(testSwitches);
        }
    }
}
