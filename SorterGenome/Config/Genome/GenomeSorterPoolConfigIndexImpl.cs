namespace SorterGenome.Config
{
    public interface IGenomeSorterPoolConfigIndex : IGenomeSorterPoolConfig
    {
        int SequenceLength { get; }
    }

    public static class GenomeSorterPoolConfigIndex
    {
        public static IGenomeSorterPoolConfigIndex Make
            (
                int keyCount,
                int genomesPerPool,
                int sequenceLength
            )
        {
            return new GenomeSorterPoolConfigIndexImpl
                (
                    keyCount: keyCount,
                    genomesPerPool: genomesPerPool,
                    sequenceLength: sequenceLength
                );
        }

    }

    public class GenomeSorterPoolConfigIndexImpl : IGenomeSorterPoolConfigIndex
    {
        public GenomeSorterPoolConfigIndexImpl(
            int keyCount, 
            int genomesPerPool, 
            int sequenceLength
            )
        {
            _keyCount = keyCount;
            _genomesPerPool = genomesPerPool;
            _sequenceLength = sequenceLength;
        }

        public GenomeSorterType GenomeSorterType
        {
            get { return GenomeSorterType.Index; }
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

        private readonly int _sequenceLength;
        public int SequenceLength
        {
            get { return _sequenceLength; }
        }
    }
}
