using System.Windows.Media;
using Sorting.KeyPairs;

namespace SorterControls.ViewModel.Sorter
{
    public class KeyPairVm
    {
        public IKeyPair KeyPair { get; set; }

        public Brush SwitchBrush { get; set; }

        public int Position { get; set; }
    }
}
