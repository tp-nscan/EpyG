namespace SorterGenome.Config
{
    public interface IGenomeSorterPoolConfig
    {
        GenomeSorterType GenomeSorterType { get; }
        int KeyCount { get; }
        int GenomesPerPool { get; }
    }
}
