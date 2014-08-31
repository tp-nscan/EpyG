using System;
using System.Collections.Generic;
using System.Linq;
using MathUtils.Collections;
using MathUtils.Rand;
using Roslyn.Compilers.CSharp;

namespace Sorting.KeyPairs
{
    public static class KeyPairRepository
    {

        #region private 

        private static readonly IKeyPair[] keyPairs;

        static KeyPairRepository()
        {
            keyPairs = new IKeyPair[KeyPairSetSizeForKeyCount(MaxKeyCount)];

            for (var hiKey = 1; hiKey < MaxKeyCount; hiKey++)
            {
                for (var lowKey = 0; lowKey < hiKey; lowKey++)
                {
                    var keyPairIndex = KeyPairIndex(lowKey, hiKey);
                    keyPairs[keyPairIndex] = new KeyPairImpl
                        (
                            index: KeyPairIndex(lowKey, hiKey),
                            lowKey: lowKey,
                            hiKey: hiKey
                        );
                }
            }
        }

        #endregion


        #region repository properties

        public const int MaxKeyCount = 64;

        public static int KeyPairSetSizeForKeyCount(int keyCount)
        {
            return (keyCount * (keyCount - 1)) / 2;
        }

        public static IEnumerable<IKeyPair> AllKeyPairsForKeyCount(int keyCount)
        {
            for (var i = 0; i < KeyPairSetSizeForKeyCount(keyCount); i++)
            {
                yield return keyPairs[i];
            }
        }






        #endregion


        #region keypair access

        public static IKeyPair AtIndex(int dex)
        {
            return keyPairs[dex];
        }

        public static int KeyPairIndex(int key1, int key2)
        {
            int lowKey;
            int hiKey;

            if (key1 == key2)
            {
                return -1;
            }

            if (key1 > key2)
            {
                lowKey = key2;
                hiKey = key1;
            }
            else
            {
                hiKey = key2;
                lowKey = key1;
            }

            if (lowKey < 0)
            {
                return -1;
            }

            if (hiKey >= MaxKeyCount)
            {
                return -1;
            }
            return KeyPairSetSizeForKeyCount(hiKey) + lowKey;
        }

        public static int KeyPairIndex(uint key1, uint key2)
        {
            int lowKey;
            int hiKey;

            if (key1 == key2)
            {
                return -1;
            }

            if (key1 > key2)
            {
                lowKey = (int) key2;
                hiKey = (int) key1;
            }
            else
            {
                hiKey = (int) key2;
                lowKey = (int) key1;
            }

            if (lowKey < 0)
            {
                return -1;
            }

            if (hiKey >= MaxKeyCount)
            {
                return -1;
            }
            return KeyPairSetSizeForKeyCount(hiKey) + lowKey;
        }

        public static IKeyPair KeyPairFromKeys(int key1, int key2)
        {
            return AtIndex(KeyPairIndex(key1, key2));
        }

        public static bool TryKeyPairFromKeys(int key1, int key2, out IKeyPair result)
        {
            var index = KeyPairIndex(key1, key2);

            if (index == -1)
            {
                result = null;
                return false;
            }

            result = AtIndex(index);
            return true;
        }

        #endregion


        #region random generation

        public static IEnumerable<IKeyPair> ToKeyPairs(this IRando rando, int keyCount)
        {
            var keyIndexCount = KeyPairSetSizeForKeyCount(keyCount);
            while (true)
            {
                yield return AtIndex(rando.NextInt(keyIndexCount));
            }
        }

        public static IEnumerable<IKeyPair> RandomKeyPairsFullStage(this IRando rando, int keyCount)
        {
            return rando.RandomFullStages(keyCount).SelectMany(kps => kps);
        }

        public static IEnumerable<List<IKeyPair>> RandomFullStages(this IRando rando, int keyCount)
        {
            IReadOnlyList<int> keys = Enumerable.Range(0, keyCount).ToList();
            while (true)
            {
                var scrambles = keys.FisherYatesShuffle(rando);
                yield return scrambles.ToTuples().ToKeyPairs(false).ToList();
            }
        }

        #endregion

        #region access using tuples

        public static IEnumerable<IKeyPair> ToKeyPairs(this IEnumerable<Tuple<int, int>> keys, bool ignoreError)
        {
            var enumerator = keys.GetEnumerator();
            if (ignoreError)
            {
                while (enumerator.MoveNext())
                {
                    IKeyPair keyOut;
                    if (TryKeyPairFromKeys(enumerator.Current.Item1, enumerator.Current.Item2, out keyOut))
                    {
                        yield return keyOut;
                    }
                }
            }
            else
            {
                while (enumerator.MoveNext())
                {
                    yield return KeyPairFromKeys(enumerator.Current.Item1, enumerator.Current.Item2);
                }
            }
        }

        public static IEnumerable<IKeyPair> ToKeyPairs(this IEnumerable<Tuple<uint, uint>> keys, bool ignoreErrors)
        {
            return keys.Select(k => new Tuple<int,int>((int) k.Item1, (int)k.Item2))
                       .ToKeyPairs(ignoreErrors);
        }

        #endregion
    }

}
