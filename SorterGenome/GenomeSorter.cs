using System;
using Genomic;
using Sorting.Sorters;

namespace SorterGenome
{
    public interface IGenomeSorter : IGenome
    {
        PhenotyperSorterType GenomeSorterType { get; }
        int KeyCount { get; }
    }

    public static class GenomeSorter
    {
        public static ISorter ToSorter(this IGenomeSorter genomeSorter)
        {
            switch (genomeSorter.GenomeSorterType)
            {
                case PhenotyperSorterType.Index:
                    return ((IGenomeSorterIndex)genomeSorter).ToSorter();
                case PhenotyperSorterType.Permutation:
                    return ((IGenomeSorterPermutation)genomeSorter).ToSorter();
                case PhenotyperSorterType.PermuSort:
                    return ((IGenomeSorterPermuSort)genomeSorter).ToSorter();
                case PhenotyperSorterType.Orbit:
                    return ((IGenomeSorterOrbit)genomeSorter).ToSorter();
                default:
                    throw new ArgumentException(String.Format("{0} not handled", genomeSorter.GenomeSorterType));
            }
        }

    }
}