using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FirstFloor.ModernUI.Presentation;
using SorterGenome;
using Sorting.Sorters;

namespace EpyG.ViewModel.Content
{
    public class RandomSorterSettingsVm
        : NotifyPropertyChanged, IDataErrorInfo
    {
        public RandomSorterSettingsVm()
        {
            ReportFrequency = 100;
            SwitchCountCutoff = 50;
            ReportFrequency = 100;
            GenomeSorterType = PhenotyperSorterType.Index;
            Seed = DateTime.Now.Millisecond;
            SuggestedKeyParam = SuggestedKeyParams[10];
        }

        private int? _switchCountCutoff;
        public int? SwitchCountCutoff
        {
            get { return _switchCountCutoff; }
            set
            {
                _switchCountCutoff = value;
                OnPropertyChanged("SwitchCountCutoff");
            }
        }

        private IList<int> _switchCountCutoffs
            = Enumerable.Empty<int>().ToList();

        public IList<int> SwitchCountCutoffs
        {
            get { return _switchCountCutoffs; }
            set
            {
                _switchCountCutoffs = value;
                OnPropertyChanged("SwitchCountCutoffs");
            }
        }

        private int? _stageCountCutoff;
        public int? StageCountCutoff
        {
            get { return _stageCountCutoff; }
            set
            {
                _stageCountCutoff = value;
                OnPropertyChanged("StageCountCutoff");
            }
        }

        private IList<int> _stageCountCutoffs
            = Enumerable.Empty<int>().ToList();

        public IList<int> StageCountCutoffs
        {
            get { return _stageCountCutoffs; }
            set
            {
                _stageCountCutoffs = value;
                OnPropertyChanged("StageCountCutoffs");
            }
        }

        private readonly IList<SuggestedKeyParam> _suggestedKeyParams 
            = SorterConstants.SuggestedKeyParams.ToList();

        public IList<SuggestedKeyParam> SuggestedKeyParams
        {
            get { return _suggestedKeyParams; }
        }

        private SuggestedKeyParam _suggestedKeyParam;
        public SuggestedKeyParam SuggestedKeyParam
        {
            get { return _suggestedKeyParam; }
            set
            {
                _suggestedKeyParam = value;
                OnPropertyChanged("SuggestedKeyParam");
                ReportFrequency = value.ReportFrequency;
                SwitchCountCutoffs = Enumerable.Range(value.LeastSwitchesKnown, SorterConstants.MaxSwitchSpan(value.KeyCount)).ToList();
                StageCountCutoffs = Enumerable.Range(value.LeastStagesKnown, SorterConstants.MaxStageSpan(value.KeyCount)).ToList();
                StageCountCutoff = value.LeastStagesKnown;
                SwitchCountCutoff = value.LeastSwitchesKnown;
                ReportFrequency = value.ReportFrequency;
                TotalSwitchCount = value.SuggestedTotalSwitches;
            }
        }

        private int? _reportFrequency;
        public int? ReportFrequency
        {
            get { return _reportFrequency; }
            set
            {
                _reportFrequency = value;
                OnPropertyChanged("ReportFrequency");
            }
        }

        private int? _seed;
        public int? Seed
        {
            get { return _seed; }
            set
            {
                _seed = value;
                OnPropertyChanged("Seed");
            }
        }

        private int? _totalSwitchCount;
        public int? TotalSwitchCount
        {
            get { return _totalSwitchCount; }
            set
            {
                _totalSwitchCount = value;
                OnPropertyChanged("TotalSwitchCount");
            }
        }

        private PhenotyperSorterType _genomeSorterType;
        public PhenotyperSorterType GenomeSorterType
        {
            get { return _genomeSorterType; }
            set
            {
                _genomeSorterType = value;
                OnPropertyChanged("GenomeSorterType");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "LowRangeMax")
                {
                    return SwitchCountCutoff.HasValue ? null : "Required value";
                }

                if (columnName == "ReportFrequency")
                {
                    return ReportFrequency.HasValue ? null : "Required value";
                }

                if (columnName == "ReportFrequency")
                {
                    return ReportFrequency.HasValue ? null : "Required value";
                }

                if (columnName == "Seed")
                {
                    return Seed.HasValue ? null : "Required value";
                }

                return null;
            }
        }


    }
}
