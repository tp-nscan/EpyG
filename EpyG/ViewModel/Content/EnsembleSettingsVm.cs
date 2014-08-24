using System;
using System.ComponentModel.Composition;
using System.Windows;
using FirstFloor.ModernUI.Presentation;
using SorterGenome;

namespace EpyG.ViewModel.Content
{
    [Export]
    public class EnsembleSettingsVm : NotifyPropertyChanged
    {

        private SorterCompPoolParameterType _sorterCompPoolParameterType;
        public SorterCompPoolParameterType SorterCompPoolParameterType
        {
            get { return _sorterCompPoolParameterType; }
            set
            {
                UpdateVisibility(_sorterCompPoolParameterType, Visibility.Visible);
                _sorterCompPoolParameterType = value;
                UpdateVisibility(_sorterCompPoolParameterType, Visibility.Collapsed);
                OnPropertyChanged("SorterCompPoolParameterType");
            }
        }

        private double _firstStep;
        public double FirstStep
        {
            get { return _firstStep; }
            set
            {
                _firstStep = value;
                OnPropertyChanged("FirstStep");
            }
        }

        private double _stepSize;
        public double StepSize
        {
            get { return _stepSize; }
            set
            {
                _stepSize = value;
                OnPropertyChanged("StepSize");
            }
        }

        private double _stepCount;
        public double StepCount
        {
            get { return _stepCount; }
            set
            {
                _stepCount = value;
                OnPropertyChanged("StepCount");
            }
        }

        void UpdateVisibility(SorterCompPoolParameterType sorterCompPoolParameterType, Visibility visibility)
        {
            switch (sorterCompPoolParameterType)
            {
                case SorterCompPoolParameterType.GenomesPerColony:
                    GenomesPerColonyVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.PhenotypesPerGenome:
                    PhenotypesPerGenomeVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.LegacyCount:
                    LegacyCountVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.CubCount:
                    CubCountVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.DeletionRate:
                    DeletionRateVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.InsertionRate:
                    InsertionRateVisibility = visibility;
                    break;
                case SorterCompPoolParameterType.MutationRate:
                    MutationRateVisibility = visibility;
                    break;
                default:
                    throw new Exception(string.Format("data type {0} not  handled", sorterCompPoolParameterType));
            }
        }

        private Visibility _genomesPerColonyVisibility;
        public Visibility GenomesPerColonyVisibility
        {
            get { return _genomesPerColonyVisibility; }
            set
            {
                _genomesPerColonyVisibility = value;
                OnPropertyChanged("GenomesPerColonyVisibility");
            }
        }

        private Visibility _phenotypesPerGenomeVisibility;
        public Visibility PhenotypesPerGenomeVisibility
        {
            get { return _phenotypesPerGenomeVisibility; }
            set
            {
                _phenotypesPerGenomeVisibility = value;
                OnPropertyChanged("PhenotypesPerGenomeVisibility");
            }
        }

        private Visibility _legacyCountVisibility;
        public Visibility LegacyCountVisibility
        {
            get { return _legacyCountVisibility; }
            set
            {
                _legacyCountVisibility = value;
                OnPropertyChanged("LegacyCountVisibility");
            }
        }

        private Visibility _cubCountVisibility;
        public Visibility CubCountVisibility
        {
            get { return _cubCountVisibility; }
            set
            {
                _cubCountVisibility = value;
                OnPropertyChanged("CubCountVisibility");
            }
        }

        private Visibility _deletionRateVisibility;
        public Visibility DeletionRateVisibility
        {
            get { return _deletionRateVisibility; }
            set
            {
                _deletionRateVisibility = value;
                OnPropertyChanged("DeletionRateVisibility");
            }
        }

        private Visibility _insertionRateVisibility;
        public Visibility InsertionRateVisibility
        {
            get { return _insertionRateVisibility; }
            set
            {
                _insertionRateVisibility = value;
                OnPropertyChanged("InsertionRateVisibility");
            }
        }

        private Visibility _mutationRateVisibility;
        public Visibility MutationRateVisibility
        {
            get { return _mutationRateVisibility; }
            set
            {
                _mutationRateVisibility = value;
                OnPropertyChanged("MutationRateVisibility");
            }
        }


    }
}
