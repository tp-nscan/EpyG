using System.Collections.Generic;
using System.Linq;
using MathUtils.Rand;
using SorterControls.ViewModel.Genome;
using Sorting.KeyPairs;

namespace SorterControls.DesignVms.Genome
{
    public class DesignSwitchListEditVm : GenomeEditorSwitchIndexVm
    {
        public DesignSwitchListEditVm()
            : base(_keyCount, KeyPairs)
        {
        }

        private const int _keyCount = 16;

        static IReadOnlyList<IKeyPair> KeyPairs
        {
            get { return Rando.Fast(123).ToKeyPairs(_keyCount).Take(1550).ToList(); }
        }
    }
}
