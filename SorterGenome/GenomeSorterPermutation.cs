using System;
using System.Collections.Generic;
using Genomic;
using MathUtils;
using MathUtils.Rand;
using Sorting.KeyPairs;
using Sorting.Sorters;

namespace SorterGenome
{
    public interface IGenomeSorterPermutation : IGenomeSorter, IGenomePermutation
    {
        IGenomePermutation GenomePermutation { get; }
    }
    
    public static class GenomeSorterPermutation
    {
        public static IGenomeSorterPermutation ToGenomeSorterPermutation
        (
            this IRando randy,
            int permutationCount,
            int keyCount
        )
        {
            return new GenomeSorterPermutationImpl(
                    guid: randy.NextGuid(),
                    genomePermutation: randy.ToPermutationGenome
                    (
                        degree: keyCount,
                        permutationCount: permutationCount
                    ),
                    keyCount: keyCount
                );
        }

        public static IGenomeSorterPermutation Make
        (
            Guid outerGuid,
            Guid innerGuid,
            IReadOnlyList<uint> sequence,
            int keyCount
        )
        {
            return new GenomeSorterPermutationImpl
                (
                    guid: outerGuid,
                    genomePermutation: GenomePermutation.Make
                    (
                        guid: innerGuid,
                        sequence: sequence,
                        degree: keyCount
                    ),
                    keyCount: keyCount
                );
        }

        public static IGenomeSorterPermutation Mutate
            (
                this IGenomeSorterPermutation genomeSorterPermutation,
                IRando randy,
                double deletionRate,
                double insertionRate,
                double mutationRate,
                int keyCount
            )
        {
            return new GenomeSorterPermutationImpl
                (
                    guid: randy.NextGuid(),
                    genomePermutation: 
                        genomeSorterPermutation
                            .GenomePermutation
                            .Mutate
                            (
                                randy: randy,
                                deletionRate: deletionRate,
                                insertionRate: insertionRate,
                                mutationRate: mutationRate
                            ),
                    keyCount: keyCount
                );

        }

        public static ISorter ToSorter(this IGenomeSorterPermutation genomeSorterPermutation)
        {
            return genomeSorterPermutation
                        .Sequence
                        .ToKeyPairs()
                        .ToSorter(genomeSorterPermutation.KeyCount);
        }

    }
    
    public class GenomeSorterPermutationImpl : IGenomeSorterPermutation
    {
        public GenomeSorterPermutationImpl
            (
                Guid guid,
                IGenomePermutation genomePermutation, 
                int keyCount
            )
        {
            _guid = guid;
            _genomePermutation = genomePermutation;
            _keyCount = keyCount;
        }

        public string EntityName
        {
            get { return "SorterGenomePermutation"; }
        }

        public IEntity GetPart(Guid key)
        {
            if (key == Guid)
            {
                return this;
            }
            return GenomePermutation.GetPart(key);
        }

        public PhenotyperSorterType GenomeSorterType
        {
            get { return PhenotyperSorterType.Permutation; }
        }

        private readonly IGenomePermutation _genomePermutation;
        public IGenomePermutation GenomePermutation
        {
            get { return _genomePermutation; }
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly Guid _guid;
        public Guid Guid
        {
            get { return _guid; }
        }

        public IReadOnlyList<uint> Sequence
        {
            get { return GenomePermutation.Sequence; }
        }

        public int SequenceLength
        {
            get { return GenomePermutation.SequenceLength; }
        }

        public uint SymbolCount
        {
            get { return GenomePermutation.SymbolCount; }
        }

        public int Degree
        {
            get { return GenomePermutation.Degree; }
        }

        public int PermutationCount
        {
            get { return GenomePermutation.PermutationCount; }
        }
    }

}
