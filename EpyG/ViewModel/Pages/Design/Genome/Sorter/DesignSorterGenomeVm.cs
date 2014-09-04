using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using SorterControls.ViewModel.Genome;
using SorterControls.ViewModel.Sorter;
using Sorting.Json.Sorters;
using Sorting.Sorters;

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
                _genomeEditorVm.OnGenomeChanged.Subscribe(UpdateGenome);
                UpdateGenome(value);
            }
        }

        protected virtual void UpdateGenome(ISorterGenomeEditorVm sorterGenomeEditorVm)
        {
            SerializedGenome = sorterGenomeEditorVm.KeyPairs.ToSorter(sorterGenomeEditorVm.KeyCount).ToJsonString();
            SorterVm = sorterGenomeEditorVm.KeyPairs
                                           .ToSorter(GenomeEditorVm.KeyCount)
                                           .ToStagedSorterVm(new SolidColorBrush(Colors.Black), 
                                                              new SolidColorBrush(Colors.WhiteSmoke));
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
