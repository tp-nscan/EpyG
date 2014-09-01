using System.ComponentModel.Composition;
using SorterControls.DesignVms.Sorter;

namespace EpyG.ViewModel.Pages.Design.Genome.Sorter
{
    [Export]
    public class DesignSorterGenomeIndexVm : DesignSorterGenomeVm
    {
        public DesignSorterGenomeIndexVm()
        {
            SorterVm = new DesignSorterVm();
        }
        //public DesignSorterGenomeIndexVm()
        //{
        //    //_switchEditVm = new SwitchListEditVm(keyCount: keyCount,
        //    //    keyPairs: Rando.Fast(123).ToKeyPairs(keyCount).Take(1550).ToList());
        //}

        //private readonly SwitchListEditVm _switchEditVm;
        //public SwitchListEditVm SwitchListEditVm
        //{
        //    get { return _switchEditVm; }
        //}


    }
}
