using System.Diagnostics;

namespace SorterGenome.Config
{
    public interface IGenomeSorterPoolConfigPermutation : IGenomeSorterPoolConfig
    {
        int PermutationCount { get; }
    }

    public static class GenomeSorterPoolConfigPermutation
    {
        public static IGenomeSorterPoolConfigPermutation Make
            (
                int keyCount,
                int genomesPerPool,
                int permutationCount
            )
        {
            return new GenomeSorterPoolConfigPermutationImpl
                (
                    keyCount: keyCount,
                    genomesPerPool: genomesPerPool,
                    permutationCount: permutationCount
                );
        }

    }

    public class GenomeSorterPoolConfigPermutationImpl : IGenomeSorterPoolConfigPermutation
    {
        public GenomeSorterPoolConfigPermutationImpl(
            int keyCount, 
            int genomesPerPool, 
            int permutationCount
            )
        {
            _keyCount = keyCount;
            _genomesPerPool = genomesPerPool;
            _permutationCount = permutationCount;
        }

        public GenomeSorterType GenomeSorterType
        {
            get { return GenomeSorterType.Permutation; }
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly int _genomesPerPool;
        public int GenomesPerPool
        {
            get { return _genomesPerPool; }
        }

        private readonly int _permutationCount;
        public int PermutationCount
        {
            get { return _permutationCount; }
        }
    }
}
