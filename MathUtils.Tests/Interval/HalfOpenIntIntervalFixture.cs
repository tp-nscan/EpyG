using System.Collections.Generic;
using System.Linq;
using MathUtils.Interval;
using MathUtils.Rand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathUtils.Tests.Interval
{
    [TestClass]
    public class HalfOpenIntIntervalFixture
    {
        [TestMethod]
        public void TestSpanRange()
        {
            const int rangeMin = 200;
            const int rangeMax = 311;
            const int span = 20;
            const int payload = 42;

            var spans = HalfOpenIntInterval.SpanRange(rangeMin, rangeMax, span, payload).ToList();

            Assert.AreEqual(spans.Count, 6);
            Assert.AreEqual(spans.Last().Span(), 11);
            Assert.AreEqual(spans.Last().Payload, payload);
        }

        [TestMethod]
        public void TestHalfOpenIntIntervalGroupAdd()
        {
            const int intervalCount = 100;
            const int max = 600000;
            const int span = 600;

            var res = HalfOpenIntIntervalGroup.Make<int>();


            foreach (var critter in RandomHalfOpenIntIntervls(intervalCount, max, span))
            {
                res = res.Add
                    (
                        critter, (a, b) => a + b
                    );

            }

            res = res.Add
                    (
                        HalfOpenIntInterval.Make(0, max, 0), (a, b) => a + b
                    );

            var total = res.HalfOpenIntIntervals.First().Payload;

            Assert.AreEqual(total, intervalCount);
        }

        [TestMethod]
        public void TestHalfOpenIntIntervalGroupGetPatches()
        {
            const int intervalCount = 3;
            const int max = 6000;
            const int largeSpan = 300;
            const int smallSpan = 200;

            var res = HalfOpenIntIntervalGroup.Make<int>();


            foreach (var critter in RandomHalfOpenIntIntervls(intervalCount, max/2, largeSpan))
            {
                res = res.Add
                    (
                        critter, (a, b) => a + b
                    );

            }

            var uncoveredSpans = res.ToPatches(-100, max, smallSpan, 1).ToList();

            Assert.IsTrue(uncoveredSpans.Any());
        }

        public IEnumerable<IHalfOpenIntInterval<int>> RandomHalfOpenIntIntervls(int count, int max, int span)
        {
            var randy = Rando.Fast(123);

            return 
                from i in Enumerable.Range(0, count)
                    let lb = randy.NextInt(max - span)
                    select HalfOpenIntInterval.Make(lb, lb+span, 1);
        }

        public IHalfOpenIntInterval<int> Baby
        {
            get { return HalfOpenIntInterval.Make(20, 40, 1); }
        }

        public IHalfOpenIntInterval<int> Mamma
        {
            get { return HalfOpenIntInterval.Make(60, 80, 1); }
        }

        public IHalfOpenIntInterval<int> Lrrh
        {
            get { return HalfOpenIntInterval.Make(30, 40, 1); }
        }

        public IHalfOpenIntInterval<int> Bbw
        {
            get { return HalfOpenIntInterval.Make(30, 80, 1); }
        }

        public IHalfOpenIntInterval<int> Pappa
        {
            get { return HalfOpenIntInterval.Make(90, 140, 1); }
        }
    }

}
