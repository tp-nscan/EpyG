using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting.Evals;
using Sorting.Stages;

namespace SorterGenome.Reporting
{
    public class SortResultReport
    {
        private const int MaxBin = 350;
        private const int LastUsedBin = 3500;

        public SortResultReport()
        {
            for (var i = 0; i < MaxBin; i++)
            {
                _switchUseCounts[i] = 0;
                _stageUseCounts[i] = 0;
            }

            for (var i = 0; i < LastUsedBin; i++)
            {
                _lastSwitchUsedCounts[i] = 0;
            }
        }

        public void AddSorterEvals(IEnumerable<ISorterEval> sorterEvals)
        {
            _switchUseDistributionReport = null;
            _stageUseDistributionReport = null;
            _lastSwitchUseDistributionReport = null;

            foreach (var sorterEval in sorterEvals)
            {

                _totalEvals++;
                if (sorterEval.Success)
                {
                    _switchUseCounts[sorterEval.SwitchUseCount]++;

                    var stagedSorter = sorterEval.ToStagedSorter(includeUnused: false);
                    _stageUseCounts[stagedSorter.SorterStages.Count]++;

                    _lastSwitchUsedCounts[sorterEval.IndexOfLastUsedSwitch]++;
                }
                else
                {
                    _sorterFails++;
                }
            }
        }

        readonly Dictionary<int, int> _lastSwitchUsedCounts = new Dictionary<int, int>();
        readonly Dictionary<int, int> _switchUseCounts = new Dictionary<int, int>();
        readonly Dictionary<int, int> _stageUseCounts = new Dictionary<int, int>();

        private string _switchUseDistributionReport;
        public string SwitchUseDistributionReport
        {
            get 
            { 
                return _switchUseDistributionReport ??
                (_switchUseDistributionReport = MakeSwitchDistributionReport());
            }
        }

        string MakeSwitchDistributionReport()
        {
            var usedBins = _switchUseCounts.Where(kvp => kvp.Value > 0).ToList();

            if (! usedBins.Any())
            {
                return String.Empty;
            }

            var minUse = usedBins.Min(kvp => kvp.Key);
            var maxUse = usedBins.Max(kvp => kvp.Key);

            var report = new StringBuilder();

            for (var i = minUse; i <= maxUse; i++)
            {
                report.Append(string.Format("{0}\t{1}\n", i, _switchUseCounts[i]));
            }
            return report.ToString();
        }

        string MakeStageDistributionReport()
        {
            var usedBins = _stageUseCounts.Where(kvp => kvp.Value > 0).ToList();

            if (!usedBins.Any())
            {
                return String.Empty;
            }

            var minUse = usedBins.Min(kvp => kvp.Key);
            var maxUse = usedBins.Max(kvp => kvp.Key);

            var report = new StringBuilder();

            for (var i = minUse; i <= maxUse; i++)
            {
                report.Append(string.Format("{0}\t{1}\n", i, _stageUseCounts[i]));
            }
            return report.ToString();
        }


        string MakeLastUsedSwitchDistributionReport()
        {
            var usedBins = _lastSwitchUsedCounts.Where(kvp => kvp.Value > 0).ToList();

            if (!usedBins.Any())
            {
                return String.Empty;
            }

            var minUse = usedBins.Min(kvp => kvp.Key);
            var maxUse = usedBins.Max(kvp => kvp.Key);

            var report = new StringBuilder();

            for (var i = minUse; i <= maxUse; i++)
            {
                report.Append(string.Format("{0}\t{1}\n", i, _lastSwitchUsedCounts[i]));
            }
            return report.ToString();
        }


        private string _lastSwitchUseDistributionReport;
        public string LastSwitchUseDistributionReport
        {
            get
            {
                return _lastSwitchUseDistributionReport ??
                (_lastSwitchUseDistributionReport = MakeLastUsedSwitchDistributionReport());
            }
        }

        private string _stageUseDistributionReport;
        public string StageUseDistributionReport
        {
            get
            {
                return _stageUseDistributionReport ??
                (_stageUseDistributionReport = MakeStageDistributionReport());
            }
        }

        public string Report
        {
            get
            {
                return string.Format
                    (
                        "Total:\n{0}\n\nFails:\n{1}\n\nSwitch Use Counts:\n{2}\n\nStage Use Counts:\n{3}\n\nLast Switch Counts:\n{4}", 
                        TotalEvals,
                        SorterFails,
                        SwitchUseDistributionReport,
                        StageUseDistributionReport,
                        LastSwitchUseDistributionReport
                    );
            }
        }

        private int _sorterFails;
        public int SorterFails
        {
            get { return _sorterFails; }
            set { _sorterFails = value; }
        }

        private int _totalEvals;
        public int TotalEvals
        {
            get { return _totalEvals; }
            set { _totalEvals = value; }
        }
    }
}
