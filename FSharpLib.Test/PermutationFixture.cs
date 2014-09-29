using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationFs;

namespace FSharpLib.Test
{
    [TestClass]
    public class PermutationFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            var permy = Permutation.createFromSeed(12, 121);

            var w = Permutation.sw;

            var tw = Permutation.switchPermute(permy, w);
        }
    }
}
