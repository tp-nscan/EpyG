using System;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    public class DesignSorterGenomeLoader : DefaultContentLoader
    {
        protected override object LoadContent(Uri uri)
        {
            if (uri.OriginalString == "/Index")
            {
                return new DesignSorterGenomeSpecIndex();
            }
            if (uri.OriginalString == "/Permutation")
            {
                return new DesignSorterGenomeSpecPermutation();
            }

            return new NavigationErrorPage(
                unknownPageLink: uri.OriginalString, 
                contentLoader: "DesignSorterGenomeLoader");
        }
    }
}
