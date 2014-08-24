﻿using System.Linq;
using MathUtils.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.Json.Sorters;
using Sorting.KeyPairs;
using Sorting.Sorters;
using Newtonsoft.Json;

namespace Sorting.Json.Test.Sorters
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConvertSorterTest()
        {
            const int keyCount = 16;
            const int sequenceLength = 100;
            var keyPairSet = KeyPairRepository.KeyPairSet(keyCount);

            var keyPairs = Enumerable.Range(0, sequenceLength)
                                     .Select(i=>keyPairSet[i])
                                     .ToArray();

            var sorter = keyPairs.ToSorter(keyCount: keyCount);

            var serialized = JsonConvert.SerializeObject(sorter.ToJsonAdapter(), Formatting.Indented);
            var newSorter = serialized.ToSorter();

            Assert.AreEqual(newSorter.KeyCount, keyCount);
            Assert.IsTrue(newSorter.KeyPairs.IsSameAs(keyPairs));
        }
    }
}
