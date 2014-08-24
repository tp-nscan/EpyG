namespace SorterGenome.Config
{
    public interface ICompPoolConfig
    {
        int PhenotypesPerCompPool { get; }
        IGenomeSorterPoolConfig GenomeSorterPoolConfig { get; }
        ISorterPhenotyperConfig SorterPhenotyperConfig { get; }
        INextGeneratorConfig NextGeneratorConfig { get; }
    }

    public static class CompPoolConfig
    {

    }

    public class CompPoolConfigImpl : ICompPoolConfig
    {


        public CompPoolConfigImpl
        (
            IGenomeSorterPoolConfig genomeSorterPoolConfig, 
            ISorterPhenotyperConfig sorterPhenotyperConfig, 
            INextGeneratorConfig nextGeneratorConfig
        )
        {
            _genomeSorterPoolConfig = genomeSorterPoolConfig;
            _sorterPhenotyperConfig = sorterPhenotyperConfig;
            _nextGeneratorConfig = nextGeneratorConfig;
        }

        public int PhenotypesPerCompPool
        {
            get { return GenomeSorterPoolConfig.GenomesPerPool * SorterPhenotyperConfig.SortersPerGenotype; }
        }

        private readonly IGenomeSorterPoolConfig _genomeSorterPoolConfig;
        public IGenomeSorterPoolConfig GenomeSorterPoolConfig
        {
            get { return _genomeSorterPoolConfig; }
        }

        private readonly ISorterPhenotyperConfig _sorterPhenotyperConfig;
        public ISorterPhenotyperConfig SorterPhenotyperConfig
        {
            get { return _sorterPhenotyperConfig; }
        }

        private readonly INextGeneratorConfig _nextGeneratorConfig;
        public INextGeneratorConfig NextGeneratorConfig
        {
            get { return _nextGeneratorConfig; }
        }
    }
}
