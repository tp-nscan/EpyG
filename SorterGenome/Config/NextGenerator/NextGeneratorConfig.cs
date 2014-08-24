namespace SorterGenome.Config
{
    public interface INextGeneratorConfig
    {
        int LegacyCount { get;  }
        int CubCount { get;  }
        double MutationRate { get;  }
        double InsertionRate { get;  }
        double DeletionRate { get;  }
    }

    public static class NextGeneratorConfig
    {
        public static INextGeneratorConfig Make (
                double mutationRate,
                double insertionRate,
                double deletionRate,
                int legacyCount,
                int cubCount
            )
        {
            return new NextGeneratorConfigImpl (
                    mutationRate: mutationRate,
                    insertionRate: insertionRate,
                    deletionRate: deletionRate,
                    legacyCount: legacyCount,
                    cubCount: cubCount
                );
        }

    }

    public class NextGeneratorConfigImpl : INextGeneratorConfig
    {
        public NextGeneratorConfigImpl (
            double mutationRate, 
            double insertionRate, 
            double deletionRate, 
            int legacyCount, 
            int cubCount
            )
        {
            _mutationRate = mutationRate;
            _insertionRate = insertionRate;
            _deletionRate = deletionRate;
            _legacyCount = legacyCount;
            _cubCount = cubCount;
        }

        private readonly int _legacyCount;
        public int LegacyCount
        {
            get { return _legacyCount; }
        }

        private readonly int _cubCount;
        public int CubCount
        {
            get { return _cubCount; }
        }

        private readonly double _mutationRate;
        public double MutationRate
        {
            get { return _mutationRate; }
        }

        private readonly double _insertionRate;
        public double InsertionRate
        {
            get { return _insertionRate; }
        }

        private readonly double _deletionRate;
        public double DeletionRate
        {
            get { return _deletionRate; }
        }
    }
}
