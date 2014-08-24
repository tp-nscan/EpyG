using System.Collections.Generic;
using System.Linq;

namespace SorterGenome.Config
{
    public interface ICompPoolEnsembleConfig
    {
        IEnumerable<ICompPoolConfig> CompPoolConfigs { get; }
    }

    public static class CompPoolEnsembleConfig
    {
        public static ICompPoolEnsembleConfig 
            MakeGenomeSorterEnsembleConfig(IEnumerable<ICompPoolConfig> compPoolConfigs)
        {
            return new CompPoolEnsembleConfigImpl(compPoolConfigs);
        }
    }

    public class CompPoolEnsembleConfigImpl : ICompPoolEnsembleConfig
    {
        public CompPoolEnsembleConfigImpl(IEnumerable<ICompPoolConfig> compPoolConfigs)
        {
            _compPoolConfigs = compPoolConfigs.ToList();
        }

        private readonly List<ICompPoolConfig> _compPoolConfigs;
        public IEnumerable<ICompPoolConfig> CompPoolConfigs
        {
            get { return _compPoolConfigs; }
        }
    }
}
