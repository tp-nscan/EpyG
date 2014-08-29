using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using FirstFloor.ModernUI.Presentation;
using Sorting.KeyPairs;

namespace SorterControls.ViewModel.Genome
{
    public class PermutationEditVm : NotifyPropertyChanged, ISorterGenomeEditorVm
    {
        public GenomeEditorType GenomeEditorType
        {
            get { return GenomeEditorType.Permutation; }
        }

        private readonly Subject<ISorterGenomeEditorVm> _onGenomeChanged
            = new Subject<ISorterGenomeEditorVm>();
        public IObservable<ISorterGenomeEditorVm> OnGenomeChanged
        {
            get { return _onGenomeChanged; }
        }

        private IReadOnlyList<IKeyPair> _keyPairs;

        public IReadOnlyList<IKeyPair> KeyPairs
        {
            get { return _keyPairs; }
        }


        private string _serialized;
        public string Serialized
        {
            get { return _serialized; }
        }
    }
}
