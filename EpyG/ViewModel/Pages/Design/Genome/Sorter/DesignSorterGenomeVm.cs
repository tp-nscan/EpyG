using System;
using System.Windows;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using SorterControls.ViewModel.Genome;

namespace EpyG.ViewModel.Pages.Design.Genome.Sorter
{
    public abstract class DesignSorterGenomeVm : NotifyPropertyChanged
    {
        private ISorterGenomeEditorVm _genomeEditorVm;

        public ISorterGenomeEditorVm GenomeEditorVm
        {
            get { return _genomeEditorVm; }
            set
            {
                _genomeEditorVm = value;
                _genomeEditorVm.OnGenomeChanged.Subscribe(ProcessGenome);
                ProcessGenome(value);
            }
        }

        protected virtual void ProcessGenome(ISorterGenomeEditorVm sorterGenomeEditorVm)
        {
            SerializedGenome = sorterGenomeEditorVm.Serialized;
        }

        private string _serializedGenome;
        public string SerializedGenome
        {
            get { return _serializedGenome; }
            set
            {
                _serializedGenome = value;
                OnPropertyChanged("SerializedGenome");
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
            Clipboard.SetText(SerializedGenome);
        }

        bool CanCopyCommand(object param)
        {
            return true;
        }

        #endregion // CopyCommand

    }

}
