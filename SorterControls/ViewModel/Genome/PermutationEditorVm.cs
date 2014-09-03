using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using FirstFloor.ModernUI.Presentation;
using Sorting.KeyPairs;

namespace SorterControls.ViewModel.Genome
{
    public class PermutationEditorVm : NotifyPropertyChanged, ISorterGenomeEditorVm
    {
        public GenomeEditorType GenomeEditorType
        {
            get { return GenomeEditorType.Permutation; }
        }

        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly Subject<ISorterGenomeEditorVm> _onGenomeChanged
            = new Subject<ISorterGenomeEditorVm>();

        private int _keyCount;

        public IObservable<ISorterGenomeEditorVm> OnGenomeChanged
        {
            get { return _onGenomeChanged; }
        }

        public IReadOnlyList<IKeyPair> KeyPairs
        {
            get { return null; }
        }

        public string Serialized
        {
            get { return String.Empty; }
        }
    }
}
