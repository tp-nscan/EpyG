using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.KeyPairs
{
    public static class KeyPair
    {

        public static bool Overlaps(this IKeyPair lhs, IKeyPair rhs)
        {
            return (lhs.LowKey == rhs.LowKey)
                   ||
                   (lhs.LowKey == rhs.HiKey)
                   ||
                   (lhs.HiKey == rhs.LowKey)
                   ||
                   (lhs.HiKey == rhs.HiKey);
        }

        #region serialization

        public static string ToString(this IEnumerable<IKeyPair> keyPairs)
        {
            return keyPairs.Aggregate(string.Empty, (acc, kp) => kp.ToString() + "; ");
        }

        public static string ToString(this IKeyPair keyPair)
        {
            return keyPair.Index.ToString();
        }

        public static IKeyPair ToKeyPair(this string strVal)
        {
            try
            {
                return KeyPairRepository.AtIndex(int.Parse(strVal));
            }
            catch (Exception)
            {
                throw new Exception("Error parsing kepair: " + strVal);
            }
        }

        public static IReadOnlyList<IKeyPair> ToKeyPairs(this string sequence)
        {
            return sequence.Split(";".ToCharArray())
                            .Select(kstr => kstr.ToKeyPair())
                            .ToList();
        }

        #endregion

    }

    class KeyPairImpl : IKeyPair
    {
        public KeyPairImpl(int index, int lowKey, int hiKey)
        {
            _index = index;
            _lowKey = lowKey;
            _hiKey = hiKey;
        }

        private readonly int _lowKey;
        public int LowKey
        {
            get { return _lowKey; }
        }

        private readonly int _hiKey;
        public int HiKey
        {
            get { return _hiKey; }
        }

        private readonly int _index;
        public int Index
        {
            get { return _index; }
        }
    }
}
