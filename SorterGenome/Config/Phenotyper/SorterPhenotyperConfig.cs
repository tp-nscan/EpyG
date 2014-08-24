namespace SorterGenome.Config
{
    public interface ISorterPhenotyperConfig
    {
        int SortersPerGenotype { get; }
    }

    public static class SorterPhenotyperConfig
    {

    }

    public class SorterPhenotyperConfigImpl : ISorterPhenotyperConfig
    {
        public SorterPhenotyperConfigImpl(int sortersPerGenotype)
        {
            _sortersPerGenotype = sortersPerGenotype;
        }

        private readonly int _sortersPerGenotype;
        public int SortersPerGenotype
        {
            get { return _sortersPerGenotype; }
        }
    }
}
