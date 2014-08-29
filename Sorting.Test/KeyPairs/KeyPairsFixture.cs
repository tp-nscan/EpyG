using System.Linq;
using MathUtils.Collections;
using MathUtils.Rand;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.KeyPairs;
using Sorting.Stages;

namespace Sorting.Test.KeyPairs
{
    [TestClass]
    public class KeyPairsFixture
    {

        [TestMethod]
        public void TestRandomFullStages()
        {
            const int keyCount = 64;
            const int stageCount = 5;

            var keyPairs = Rando.Fast(1111).RandomFullStages(keyCount)
                                      .Take(stageCount)
                                      .SelectMany(s => s)
                                      .ToList();

            var stages = keyPairs.ToSorterStages(keyCount)
                            .ToList();

            Assert.AreEqual(stageCount, stages.Count());
            Assert.AreEqual(stages.SelectMany(s => s.KeyPairs).Count(), keyPairs.Count());
        }

        [TestMethod]
        public void TestKeyPairSerialization()
        {
            const int keyCount = 16;
            const int keyPairCount = 5;

            var keyPairs = Rando.Fast(1111)
                                .ToKeyPairs(keyCount)
                                .Take(keyPairCount)
                                .ToList();

            var serialized = keyPairs.ToSerialized();

            var deserialzied = serialized.ToKeyPairs().ToList();

            Assert.AreEqual(keyPairs.GetDiffs(deserialzied, (a,b) => a.Index == b.Index).Count(), 0);
        }


    }
}
