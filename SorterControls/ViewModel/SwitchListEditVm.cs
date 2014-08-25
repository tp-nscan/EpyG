using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sorting.KeyPairs;

namespace SorterControls.ViewModel
{
    public class SwitchListEditVm
    {
        public SwitchListEditVm(int keyCount, IEnumerable<IKeyPair> keyPairs)
        {
            _keyCount = keyCount;
            _switchEditVms = new ObservableCollection<SwitchEditVm>(

                    keyPairs.ToList()
                        .Select(
                            (kp, i)=> 
                                new SwitchEditVm(KeyCount)
                                        {Index = i, 
                                        LowKey = kp.LowKey, 
                                        HiKey = kp.HiKey}
                               )
                );
        }


        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private ObservableCollection<SwitchEditVm> _switchEditVms 
            = new ObservableCollection<SwitchEditVm>();
        public ObservableCollection<SwitchEditVm> SwitchEditVms
        {
            get { return _switchEditVms; }
            set { _switchEditVms = value; }
        }


    }
}
