using System.ComponentModel;
using FirstFloor.ModernUI.Presentation;

namespace SorterControls.ViewModel
{
    public class SwitchEditVm : NotifyPropertyChanged, 
            IDataErrorInfo
    {
        public SwitchEditVm(int keyCount)
        {
            _keyCount = keyCount;
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChanged("Index");
            }
        }

        private int? _lowKey;
        public int? LowKey
        {
            get { return _lowKey; }
            set
            {
                _lowKey = value;
                OnPropertyChanged("LowKey");
            }
        }

        private int? _hiKey;
        public int? HiKey
        {
            get { return _hiKey; }
            set
            {
                _hiKey = value;
                OnPropertyChanged("HiKey");
            }
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "LowKey")
                {
                    return (LowKey.IsAValidLowKey(HiKey, KeyCount)) ? null : "Incorrect key value";
                }
                if (columnName == "HiKey")
                {
                    return (HiKey.IsAValidHiKey(LowKey, KeyCount)) ? null : "Incorrect key value";
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
