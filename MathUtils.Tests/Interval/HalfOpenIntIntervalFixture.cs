using System;
using System.Collections.Immutable;
using System.Linq;
using MathUtils.Interval;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathUtils.Tests.Interval
{
    [TestClass]
    public class HalfOpenIntIntervalFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testList = ImmutableList<int>.Empty.AddRange(Enumerable.Range(3, 3));

            var dax = testList.FindIndex(i => i == 8);

            var newList = testList.Insert(-1, 77);
        }


        public IHalfOpenIntInterval Baby
        {
            get { return HalfOpenIntInterval.Make(2, 4); }
        }

        public IHalfOpenIntInterval Mamma
        {
            get { return HalfOpenIntInterval.Make(6, 8); }
        }

        public IHalfOpenIntInterval Pappa
        {
            get { return HalfOpenIntInterval.Make(9, 14); }
        }
    }

}
