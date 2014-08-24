
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using MathUtils.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathUtils.Tests.Collections
{
    [TestClass]
    public class QueueFixture
    {
        [TestMethod]
        public void TestDequeAChunk()
        {
            const int queueSize = 17;
            const int chunkSize = 10;

            var testQueue = new Queue<int>(Enumerable.Range(0, queueSize));

            var chunkOne = testQueue.DequeAChunk(chunkSize).ToList();
            Assert.AreEqual(chunkOne.Count, chunkSize);

            var chunkTwo = testQueue.DequeAChunk(chunkSize).ToList();
            Assert.AreEqual(chunkTwo.Count, queueSize - chunkSize);

            var chunkThree = testQueue.DequeAChunk(chunkSize).ToList();
            Assert.AreEqual(chunkThree.Count, 0);
        }

        [TestMethod]
        public void TestPopAChunk()
        {
            const int queueSize = 17;
            const int chunkSize = 10;

            var testStack  = ImmutableStack.Create(Enumerable.Range(0, queueSize).ToArray());

            var chunkOne = testStack.PopAChunk(chunkSize);
            Assert.AreEqual(chunkOne.Item1.Count, chunkSize);

            var chunkTwo = chunkOne.Item2.PopAChunk(chunkSize);
            Assert.AreEqual(chunkTwo.Item1.Count, queueSize - chunkSize);

            var chunkThree = chunkTwo.Item2.PopAChunk(chunkSize);
            Assert.AreEqual(chunkThree.Item1.Count, 0);
        }

    }
}
