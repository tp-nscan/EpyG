using SorterControls.ViewModel;

namespace SorterControls.DesignVms
{
    public class DesignSwitchEditVm : SwitchEditVm
    {
        public DesignSwitchEditVm() : base(16)
        {
            Index = 1004;
            LowKey = 5;
            HiKey = 11;
        }
    }
}
