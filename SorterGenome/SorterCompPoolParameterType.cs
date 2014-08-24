using System;
using System.Collections.Generic;
using System.Linq;

namespace SorterGenome
{
    public enum SorterCompPoolParameterType
    {
        GenomesPerColony,
        PhenotypesPerGenome,
        LegacyCount,
        CubCount,
        DeletionRate,
        InsertionRate,
        MutationRate
    }

    public class SorterCompPoolParameterTypeSetting
    {
        public SorterCompPoolParameterType SorterCompPoolParameterType { get; set; }

        public Type DataType { get; set; }
    }

    public static class SorterCompPoolParameterTypeSettings
    {
        public static IEnumerable<SorterCompPoolParameterTypeSetting> Values
        {
            get
            {
                yield return
                    new SorterCompPoolParameterTypeSetting()
                    {
                        SorterCompPoolParameterType = SorterCompPoolParameterType.DeletionRate,
                        DataType = typeof (double)
                    };

                yield return
                    new SorterCompPoolParameterTypeSetting()
                    {
                        SorterCompPoolParameterType = SorterCompPoolParameterType.InsertionRate,
                        DataType = typeof(double)
                    };

                yield return
                    new SorterCompPoolParameterTypeSetting()
                    {
                        SorterCompPoolParameterType = SorterCompPoolParameterType.MutationRate,
                        DataType = typeof(double)
                    };
            }
        }

        public static IEnumerable<double> MutationRates
        {
            get { return Enumerable.Range(0, 20).Select(i => (double) i/200); }
        }

        public static IEnumerable<double> InsertionRates
        {
            get { return Enumerable.Range(0, 20).Select(i => (double)i / 200); }
        }

        public static IEnumerable<double> DeletionRates
        {
            get { return Enumerable.Range(0, 20).Select(i => (double)i / 200); }
        }

        public static IEnumerable<int> ColonySizes(int keyCount, int colonyCount)
        {
            return Enumerable.Range(0, EnsembleExponentsForKeyCount(keyCount))
                             .Select(i => (2 ^ i) / colonyCount);
        }

        public static IEnumerable<int> ColonyCounts()
        {
            return Enumerable.Range(0, 5).Select(i => 2 ^ i);
        }

        public static int EnsembleExponentsForKeyCount(int keyCount)
        {
            switch (keyCount)
            {
                case 2:
                    return 16;
                case 3:
                    return 16;
                case 4:
                    return 16;
                case 5:
                    return 15;
                case 6:
                    return 15;
                case 7:
                    return 15;
                case 8:
                    return 14;
                case 10:
                    return 14;
                case 11:
                    return 13;
                case 12:
                    return 14;
                case 13:
                    return 13;
                case 14:
                    return 13;
                case 15:
                    return 12;
                case 16:
                    return 12;
                case 17:
                    return 10;
                case 18:
                    return 10;
                case 19:
                    return 10;
                case 20:
                    return 10;
                case 21:
                    return 9;
                case 22:
                    return 9;
                case 23:
                    return 9;
                case 24:
                    return 9;
                default:
                    throw new ArgumentException(String.Format("keyCount {0} not handled", keyCount));
            }

        }

    }
}
