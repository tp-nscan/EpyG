using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FirstFloor.ModernUI.Presentation;
using Sorting.Sorters;

namespace EpyG.ViewModel.Pages.Design.Genome
{
    [Export]
    public class DesignSorterGenomeSpecPermutationVm : NotifyPropertyChanged
    {
        public DesignSorterGenomeSpecPermutationVm()
        {
            SuggestedKeyParam = _suggestedKeyParams[9];
        }

        private readonly IList<SuggestedKeyParam> _suggestedKeyParams
            = SorterConstants.SuggestedKeyParams.ToList();
        public IList<SuggestedKeyParam> SuggestedKeyParams
        {
            get { return _suggestedKeyParams; }
        }

        private SuggestedKeyParam _suggestedKeyParam;
        public SuggestedKeyParam SuggestedKeyParam
        {
            get { return _suggestedKeyParam; }
            set
            {
                _suggestedKeyParam = value;
                OnPropertyChanged("SuggestedKeyParam");
            }
        }
    }
}
