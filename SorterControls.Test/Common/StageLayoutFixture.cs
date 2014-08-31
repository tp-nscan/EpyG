using System;
using System.Linq;
using MathUtils.Collections;
using MathUtils.Rand;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.KeyPairs;
using Sorting.Stages;

namespace SorterControls.Test.Common
{
    [TestClass]
    public class StageLayoutFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int keyCount = 16;

            var p = Rando.Fast(123).ToPermutations(keyCount)
                                .First()
                                .Values
                                .ToTuples()
                                .ToKeyPairs(false)
                                .ToSorterStage(keyCount);


        }
    }
}
