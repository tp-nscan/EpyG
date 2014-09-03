using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using MathUtils.Rand;
using Sorting.KeyPairs;
using Sorting.Sorters;

namespace EpyG.ViewModel.Pages.Design.Genome.Sorter
{
    [Export]
    public class DesignSorterGenomeSpecIndexVm : NotifyPropertyChanged, IDataErrorInfo
    {
        public DesignSorterGenomeSpecIndexVm()
        {
            SuggestedKeyParam = _suggestedKeyParams[9];
        }

        private readonly IList<SuggestedKeyParam> _suggestedKeyParams
            = SorterConstants.SuggestedKeyParams.ToList();
        public IList<SuggestedKeyParam> SuggestedKeyParams
        {
            get { return _suggestedKeyParams; }
        }

        private SuggestedKeyParam _suggestedKeyParam;
        private string _serializedGenomeSequence;
        public SuggestedKeyParam SuggestedKeyParam
        {
            get { return _suggestedKeyParam; }
            set
            {
                _suggestedKeyParam = value;
                SerializedGenomeSequence = Rando.Fast(123).ToKeyPairs(value.KeyCount).Take(200).ToSerialized();
                OnPropertyChanged("SuggestedKeyParam");
            }
        }

        public string SerializedGenomeSequence
        {
            get { return _serializedGenomeSequence; }
            set
            {
                _serializedGenomeSequence = value;
                SequenceWasParsedCorrectly = ParseGenomeSequence();
                OnPropertyChanged("SerializedGenomeSequence");
            }
        }

        bool ParseGenomeSequence()
        {
            try
            {
                KeyPairs = null;
                KeyPairs = SerializedGenomeSequence.ToKeyPairs().ToList();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IReadOnlyList<IKeyPair> KeyPairs { get; set; } 

        private bool _sequenceWasParsedCorrectly = true;
        public bool SequenceWasParsedCorrectly
        {
            get { return _sequenceWasParsedCorrectly; }
            set
            {
                if (_sequenceWasParsedCorrectly != value)
                {
                    _sequenceWasParsedCorrectly = value;
                    OnPropertyChanged("SequenceWasParsedCorrectly");
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }


        public string this[string columnName]
        {
            get
            {
                if (columnName == "SerializedGenomeSequence")
                {
                    return (_sequenceWasParsedCorrectly) ? null : "Incorrect genome sequence";
                }
                return null;
            }
        }

        public string Error
        {
            get { return null; }
        }

    }
}
