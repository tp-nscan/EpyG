using System.ComponentModel.Composition;
using FirstFloor.ModernUI.Presentation;
using SorterControls.ViewModel;

namespace EpyG.ViewModel.Pages.Design
{
    [Export]
    public class DesignSorterGenomeVm : NotifyPropertyChanged
    {
        public DesignSorterGenomeVm()
        {
        }

        private SwitchEditVm _switchEditVm;
        public SwitchEditVm SwitchEditVm
        {
            get { return _switchEditVm; }
        }

        private int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
            set
            {
                _keyCount = value;
                _switchEditVm = new SwitchEditVm(keyCount : _keyCount)
                {
                    Index = 1777,
                    HiKey = _keyCount - 1, 
                    LowKey = _keyCount - 2
                };
                OnPropertyChanged("KeyCount");
            }
        }
    }
}
