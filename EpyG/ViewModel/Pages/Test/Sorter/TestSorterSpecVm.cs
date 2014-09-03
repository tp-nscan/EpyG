using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using Sorting.Json.Sorters;
using Sorting.KeyPairs;

namespace EpyG.ViewModel.Pages.Test.Sorter
{
    [Export]
    public class TestSorterSpecVm : NotifyPropertyChanged, IDataErrorInfo
    {
        private string _switches;
        public string Switches
        {
            get { return _switches; }
            set
            {
                _switches = value;
                OnPropertyChanged("Switches");
            }
        }

        private int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
            set
            {
                _keyCount = value;
                OnPropertyChanged("KeyCount");
            }
        }

        private string _sorterJson;
        public string SorterJson
        {
            get { return _sorterJson; }
            set
            {
                _sorterJson = value;
                if (! string.IsNullOrEmpty(value))
                {
                    SequenceWasParsedCorrectly = ParseGenomeSequence();
                }
                OnPropertyChanged("SorterJson");
            }
        }

        //private string _serializedGenomeSequence;
        //public string SerializedGenomeSequence
        //{
        //    get { return _serializedGenomeSequence; }
        //    set
        //    {
        //        _serializedGenomeSequence = value;
        //        SequenceWasParsedCorrectly = ParseGenomeSequence();
        //        OnPropertyChanged("SerializedGenomeSequence");
        //    }
        //}

        bool ParseGenomeSequence()
        {
            try
            {
                var sorter = SorterJson.ToSorter();
                KeyCount = sorter.KeyCount;
                Switches = sorter.KeyPairs.ToSerialized();
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
                if (columnName == "SorterJson")
                {
                    return (_sequenceWasParsedCorrectly) ? null : "Incorrect sorter JSON";
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
