using System.Collections.Generic;
using System.Linq;
using MathUtils.Rand;
using SorterControls.ViewModel;
using Sorting.KeyPairs;

namespace SorterControls.DesignVms
{
    public class DesignSwitchListEditVm : SwitchListEditVm
    {
        public DesignSwitchListEditVm()
            : base(_keyCount, KeyPairs)
        {
        }

        private static int _keyCount = 16;

        static IEnumerable<IKeyPair> KeyPairs
        {
            get { return Rando.Fast(123).ToKeyPairs(_keyCount).Take(50); }
        }
    }
}
