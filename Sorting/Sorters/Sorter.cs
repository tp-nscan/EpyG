using System.Collections.Generic;
using System.Linq;
using MathUtils.Collections;
using MathUtils.Rand;
using Sorting.KeyPairs;

namespace Sorting.Sorters
{
    public interface ISorter
    {
        int KeyCount { get; }
        int KeyPairCount { get; }
        IKeyPair KeyPair(int index);
        IReadOnlyList<IKeyPair> KeyPairs { get; }
    }

    public static class Sorter
    {
        public static ISorter ToSorter(this IEnumerable<IKeyPair> keyPairs, int keyCount)
        {
            return new SorterImpl(keyPairs, keyCount);
        }

        public static ISorter ToSorter(this IEnumerable<int> keyIndexes, int keyCount)
        {
            return keyIndexes.Select(KeyPairRepository.AtIndex)
                    .ToSorter(keyCount);
        }

        public static ISorter ToSorter(this IEnumerable<uint> keyIndexes, int keyCount)
        {
            return keyIndexes.Select(i => KeyPairRepository.AtIndex((int)i))
                    .ToSorter(keyCount);
        }

        public static ISorter ToSorter(this IReadOnlyList<IKeyPair> keyPairs, IEnumerable<uint> keyPairChoices, int keyCount)
        {
            return keyPairs.PickMembers(keyPairChoices).ToSorter(keyCount);
        }

        public static ISorter ToSorter(this IRando rando, int keyCount, int keyPairCount)
        {
           return rando.ToKeyPairs(keyCount).Take(keyPairCount).ToSorter(keyCount);
        }

        public static ISorter ToSorter(this IRando rando, IReadOnlyList<IKeyPair> keyPairs, int keyPairCount, int keyCount)
        {
            return rando.Pick(keyPairs).Take(keyPairCount).ToSorter(keyCount);
        }

    }

    class SorterImpl : ISorter
    {
        public SorterImpl(IEnumerable<IKeyPair> keyPairs, int keyCount)
        {
            _keyCount = keyCount;
            _keyPairs = keyPairs.ToArray();
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        public int KeyPairCount
        {
            get { return _keyPairs.Length; }
        }

        private readonly IKeyPair[] _keyPairs;
        public IKeyPair KeyPair(int index)
        {
            return _keyPairs[index];
        }

        public IReadOnlyList<IKeyPair> KeyPairs
        {
            get { return _keyPairs; }
        }
    }
}
