using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SorterFsOld;

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
            var res = SwitchFunctions.SpanFolder(16);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res));
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

            var res = SwitchFunctions.SwitchListOffset(testSwitches, 2);
        }

        [TestMethod]
        public void TestSwitchListArrayExtend()
        {
            var testSwitches = new[]
            {
                new Switch(0, 2),
                //new Switch(0, 2),
                //new Switch(0, 3)
            }.AsEnumerable();

            var res = SwitchFunctions.SwitchListArrayExtend(testSwitches, 1, 2);

            var res2 = SwitchFunctions.SwitchListArrayExtend(res, 4, 4);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res2));
        }

        [TestMethod]
        public void TestNestedSwitchArray()
        {
            var res = SwitchFunctions.NestedSwitchArray(new Switch(0, 2), 1, 2, 4, 2);

            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res));
        }

        [TestMethod]
        public void TestBitonicNestedSwitchArray()
        {
            var res = SwitchFunctions.BitonicNestedSwitchArray(4,2);

            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res));
        }


        [TestMethod]
        public void TestBitonicSuffix()
        {
            var res = SwitchFunctions.BitonicSuffix(1);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(res));
        }

        [TestMethod]
        public void TestAppendBelow()
        {
            var testSwitches = new[]
            {
                new Switch(0, 1),
                new Switch(0, 2),
                new Switch(0, 3)
            };

            var appended = SwitchFunctions.AppendBelow(testSwitches, 4);
            System.Diagnostics.Debug.WriteLine(SwitchFunctions.SwitchListReport(appended));

        }

        [TestMethod]
        public void TestBitonicSwitches()
        {
            var appended = BitonicFunctions.BitonicSwitches(5);
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
