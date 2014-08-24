using System.Collections.Generic;

namespace Sorting.Sorters
{
    public static class SorterConstants
    {
        static SorterConstants()
        {
            suggestedKeyParams[2] = new SuggestedKeyParam(keyCount: 2, leastSwitchesKnown: 1, leastStagesKnown: 1, averageSwitches: 1, averageStages: 1, suggestedTotalSwitches: 2, reportFrequency: 1000);
            suggestedKeyParams[3] = new SuggestedKeyParam(keyCount: 3, leastSwitchesKnown: 3, leastStagesKnown: 3, averageSwitches: 3, averageStages: 2, suggestedTotalSwitches: 15, reportFrequency: 1000);
            suggestedKeyParams[4] = new SuggestedKeyParam(keyCount: 4, leastSwitchesKnown: 5, leastStagesKnown: 3, averageSwitches: 5, averageStages: 3, suggestedTotalSwitches: 25, reportFrequency: 1000);
            suggestedKeyParams[5] = new SuggestedKeyParam(keyCount: 5, leastSwitchesKnown: 9, leastStagesKnown: 5, averageSwitches: 9, averageStages: 6, suggestedTotalSwitches: 45, reportFrequency: 1000);

            suggestedKeyParams[6] = new SuggestedKeyParam(keyCount: 6, leastSwitchesKnown: 12, leastStagesKnown: 5, averageSwitches: 2, averageStages: 10, suggestedTotalSwitches: 80, reportFrequency: 1000);

            suggestedKeyParams[7] = new SuggestedKeyParam(keyCount: 7, leastSwitchesKnown: 16, leastStagesKnown: 6, averageSwitches: 2, averageStages: 14, suggestedTotalSwitches: 120, reportFrequency: 1000);
            suggestedKeyParams[8] = new SuggestedKeyParam(keyCount: 8, leastSwitchesKnown: 19, leastStagesKnown: 6, averageSwitches: 2, averageStages: 14, suggestedTotalSwitches: 170, reportFrequency: 1000);
            suggestedKeyParams[9] = new SuggestedKeyParam(keyCount: 9, leastSwitchesKnown: 25, leastStagesKnown: 7, averageSwitches: 2, averageStages: 14, suggestedTotalSwitches: 230, reportFrequency: 1000);
            suggestedKeyParams[10] = new SuggestedKeyParam(keyCount: 10, leastSwitchesKnown: 29, leastStagesKnown: 7, averageSwitches: 2, averageStages: 16, suggestedTotalSwitches: 290, reportFrequency: 1000);
            suggestedKeyParams[11] = new SuggestedKeyParam(keyCount: 11, leastSwitchesKnown: 35, leastStagesKnown: 8, averageSwitches: 2, averageStages: 16, suggestedTotalSwitches: 360, reportFrequency: 100);
            suggestedKeyParams[12] = new SuggestedKeyParam(keyCount: 12, leastSwitchesKnown: 39, leastStagesKnown: 8, averageSwitches: 2, averageStages: 16, suggestedTotalSwitches: 450, reportFrequency: 100);
            suggestedKeyParams[13] = new SuggestedKeyParam(keyCount: 13, leastSwitchesKnown: 45, leastStagesKnown: 9, averageSwitches: 2, averageStages: 20, suggestedTotalSwitches: 540, reportFrequency: 100);
            suggestedKeyParams[14] = new SuggestedKeyParam(keyCount: 14, leastSwitchesKnown: 51, leastStagesKnown: 9, averageSwitches: 2, averageStages: 20, suggestedTotalSwitches: 650, reportFrequency: 10);
            suggestedKeyParams[15] = new SuggestedKeyParam(keyCount: 15, leastSwitchesKnown: 56, leastStagesKnown: 9, averageSwitches: 2, averageStages: 20, suggestedTotalSwitches: 760, reportFrequency: 10);
            suggestedKeyParams[16] = new SuggestedKeyParam(keyCount: 16, leastSwitchesKnown: 60, leastStagesKnown: 9, averageSwitches: 2, averageStages: 20, suggestedTotalSwitches: 890, reportFrequency: 10);
            suggestedKeyParams[17] = new SuggestedKeyParam(keyCount: 17, leastSwitchesKnown: 73, leastStagesKnown: 11, averageSwitches: 2, averageStages: 22, suggestedTotalSwitches: 1020, reportFrequency: 10);
            suggestedKeyParams[18] = new SuggestedKeyParam(keyCount: 18, leastSwitchesKnown: 80, leastStagesKnown: 11, averageSwitches: 2, averageStages: 24, suggestedTotalSwitches: 1180, reportFrequency: 10);
            suggestedKeyParams[19] = new SuggestedKeyParam(keyCount: 19, leastSwitchesKnown: 88, leastStagesKnown: 12, averageSwitches: 2, averageStages: 24, suggestedTotalSwitches: 1350, reportFrequency: 10);
            suggestedKeyParams[20] = new SuggestedKeyParam(keyCount: 20, leastSwitchesKnown: 93, leastStagesKnown: 12, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 1520, reportFrequency: 1);
            suggestedKeyParams[21] = new SuggestedKeyParam(keyCount: 21, leastSwitchesKnown: 103, leastStagesKnown: 12, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 1720, reportFrequency: 1);
            suggestedKeyParams[22] = new SuggestedKeyParam(keyCount: 22, leastSwitchesKnown: 110, leastStagesKnown: 12, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 1950, reportFrequency: 1);
            suggestedKeyParams[23] = new SuggestedKeyParam(keyCount: 23, leastSwitchesKnown: 118, leastStagesKnown: 13, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 2250, reportFrequency: 1);
            suggestedKeyParams[24] = new SuggestedKeyParam(keyCount: 24, leastSwitchesKnown: 123, leastStagesKnown: 13, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 2600, reportFrequency: 1);
            suggestedKeyParams[25] = new SuggestedKeyParam(keyCount: 25, leastSwitchesKnown: 133, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[26] = new SuggestedKeyParam(keyCount: 26, leastSwitchesKnown: 140, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[27] = new SuggestedKeyParam(keyCount: 27, leastSwitchesKnown: 150, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[28] = new SuggestedKeyParam(keyCount: 28, leastSwitchesKnown: 157, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[29] = new SuggestedKeyParam(keyCount: 29, leastSwitchesKnown: 166, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[31] = new SuggestedKeyParam(keyCount: 31, leastSwitchesKnown: 180, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
            suggestedKeyParams[32] = new SuggestedKeyParam(keyCount: 32, leastSwitchesKnown: 185, leastStagesKnown: 14, averageSwitches: 2, averageStages: 28, suggestedTotalSwitches: 8000, reportFrequency: 1);
        }

        static readonly Dictionary<int, SuggestedKeyParam> suggestedKeyParams 
            = new Dictionary<int, SuggestedKeyParam>();

        public static SuggestedKeyParam SuggestedKeyParam(int keyCount)
        {
            return (suggestedKeyParams.ContainsKey(keyCount)) ? suggestedKeyParams[keyCount] : null;
        }

        public static IEnumerable<SuggestedKeyParam> SuggestedKeyParams
        {
            get { return suggestedKeyParams.Values; }
        }

        public static int MaxSwitchSpan(int keyCount)
        {
            if (keyCount <= 2)
            {
                return 1;
            }
            if (keyCount <= 10)
            {
                return keyCount;
            }
            if (keyCount <= 14)
            {
                return keyCount*2;
            }

            return (keyCount * 3);

        }

        public static int MaxStageSpan(int keyCount)
        {
            if (keyCount <= 2)
            {
                return 1;
            }

            return keyCount /2;
        }

    }

    public class SuggestedKeyParam
    {
        public SuggestedKeyParam
        (
            int keyCount, 
            int leastSwitchesKnown, 
            int leastStagesKnown, 
            int averageSwitches, 
            int averageStages, 
            int suggestedTotalSwitches, 
            int reportFrequency
        )
        {
            _keyCount = keyCount;
            _leastSwitchesKnown = leastSwitchesKnown;
            _leastStagesKnown = leastStagesKnown;
            _averageSwitches = averageSwitches;
            _averageStages = averageStages;
            _suggestedTotalSwitches = suggestedTotalSwitches;
            _reportFrequency = reportFrequency;
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly int _leastSwitchesKnown;
        public int LeastSwitchesKnown
        {
            get { return _leastSwitchesKnown; }
        }

        private readonly int _leastStagesKnown;
        public int LeastStagesKnown
        {
            get { return _leastStagesKnown; }
        }

        private readonly int _averageSwitches;
        public int AverageSwitches
        {
            get { return _averageSwitches; }
        }

        private readonly int _averageStages;
        public int AverageStages
        {
            get { return _averageStages; }
        }

        private readonly int _suggestedTotalSwitches;
        public int SuggestedTotalSwitches
        {
            get { return _suggestedTotalSwitches; }
        }

        private readonly int _reportFrequency;
        public int ReportFrequency
        {
            get { return _reportFrequency; }
        }
    }
}
