using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using SorterControls.ViewModel.Sorter;
using SorterControls.ViewModel.Test;

namespace EpyG.ViewModel.Pages.Test.Sorter
{
    [Export]
    public class TestSorterVm : NotifyPropertyChanged
    {
        private MakeSorterEvalVm _makeSorterEvalVm;
        public MakeSorterEvalVm MakeSorterEvalVm
        {
            get { return _makeSorterEvalVm; }
            set
            {
                _makeSorterEvalVm = value;
                OnPropertyChanged("MakeSorterEvalVm");
            }
        }

        private ISorterVm _sorterVm;
        public ISorterVm SorterVm
        {
            get { return _sorterVm; }
            set
            {
                _sorterVm = value;
                OnPropertyChanged("SorterVm");
            }
        }

        private string _serializedSorterEval;
        public string SerializedSorterEval
        {
            get { return _serializedSorterEval; }
            set
            {
                _serializedSorterEval = value;
                OnPropertyChanged("SerializedSorterEval");
            }
        }

        #region CopyCommand

        RelayCommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                return _copyCommand ?? (_copyCommand
                    = new RelayCommand
                        (
                            OnCopyCommand,
                            CanCopyCommand
                        ));
            }
        }

        protected void OnCopyCommand(object param)
        {
            Clipboard.SetText(SerializedSorterEval);
        }

        bool CanCopyCommand(object param)
        {
            return true;
        }

        #endregion // CopyCommand


    }
}
