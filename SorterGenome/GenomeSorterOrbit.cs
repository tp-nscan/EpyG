using System;
using System.Collections.Generic;
using System.Linq;
using Genomic;
using MathUtils;
using MathUtils.Collections;
using MathUtils.Rand;
using Sorting.KeyPairs;
using Sorting.Sorters;

namespace SorterGenome
{
    public interface IGenomeSorterOrbit : IGenomeSorter
    {
        int PermutationCount { get; }
    }

    public static class GenomeSorterOrbit
    {
        public static IGenomeSorterOrbit ToGenomeSorterOrbit
        (
            this IRando randy,
            int keyCount, 
            int permutationCount
        )
        {
            return new GenomeSorterOrbitImpl(
                    guid: randy.NextGuid(),
                    genome: randy.ToPermutationGenome
                    (
                        degree: keyCount,
                        permutationCount: 2
                    ),
                    keyCount: keyCount,
                    permutationCount: permutationCount
                );
        }

        public static IGenomeSorterOrbit Make
        (
            Guid outerGuid,
            Guid innerGuid,
            IReadOnlyList<uint> sequence,
            int keyCount, 
            int permutationCount
        )
        {
            return new GenomeSorterOrbitImpl
                (
                    guid: outerGuid,
                    genome: GenomePermutation.Make
                    (
                        guid: innerGuid,
                        sequence: sequence,
                        degree: keyCount
                    ),
                    keyCount: keyCount,
                    permutationCount: permutationCount
                );
        }

        public static ISorter ToSorter(this IGenomeSorterOrbit genomeSorterOrbit)
        {

            var permutations = genomeSorterOrbit.Sequence.ToPermutations(genomeSorterOrbit.KeyCount).ToList();

            var permutation =  Enumerable.Range(0, genomeSorterOrbit.KeyCount)
                                .ToList()
                                .ToPermutation()
                                .Iterate()
                                .Smash(permutations[1].Iterate(), (lhs, rhs) => lhs.Compose(rhs))
                                .Take(genomeSorterOrbit.PermutationCount)
                                .SelectMany(p => p.Values.Cast<uint>())
                                .ToList();

            return permutation
                            .ToTuples()
                            .ToKeyPairs(ignoreErrors:false)
                            .ToSorter(genomeSorterOrbit.KeyCount);
        }

        //public static ISorter ToSorter(this IGenomeSorterOrbit genomeSorterOrbit)
        //{
        //    var randy = Rando.Fast(123);
        //    const double mutationRate = 0.2;

        //    var permutations = genomeSorterOrbit.Sequence.ToPermutations(genomeSorterOrbit.KeyCount).ToList();

        //    var permutation = permutations[0]
        //                        .Iterate()
        //                        .Smash(permutations[1].Iterate(), (lhs, rhs) => lhs.Compose(rhs))
        //                        .Take(genomeSorterOrbit.PermutationCount)
        //                        .SelectMany(p => p.Values.Cast<uint>())
        //                        .ToList();

        //    return permutation.ToKeyPairs().ToSorter(genomeSorterOrbit.KeyCount);
        //}

        //public static ISorter ToSorter(this IGenomeSorterOrbit genomeSorterOrbit)
        //{
        //    var randy = Rando.Fast(123);
        //    const double mutationRate = 0.2;

        //    var permutations = genomeSorterOrbit.Sequence.ToPermutations(genomeSorterOrbit.KeyCount).ToList();

        //    var permutation = permutations[0]
        //                        .Iterate()
        //                        .Select(p=>p.Mutate(randy, mutationRate))
        //                        .Take(genomeSorterOrbit.PermutationCount)
        //                        .SelectMany(p => p.Values.Cast<uint>())
        //                        .ToList();

        //    return permutation.ToKeyPairs().ToSorter(genomeSorterOrbit.KeyCount);
        //}

        //public static ISorter ToSorter(this IGenomeSorterOrbit genomeSorterOrbit)
        //{
        //    var permutations = genomeSorterOrbit.Sequence.ToPermutations(genomeSorterOrbit.KeyCount).ToList();

        //    var orbit0 = permutations[0].ToOrbit().RoundRobin(0);

        //    var orbit1 = permutations[1].ToOrbit().RoundRobin(0);

        //    var permutation = genomeSorterOrbit.Sequence
        //                                        .ToPermutation()
        //                                        .Iterate()
        //                                        .Take(genomeSorterOrbit.PermutationCount)
        //                                        .SelectMany(p => p.Values.Cast<uint>())
        //                                        .ToList();

        //    return permutation.ToKeyPairs().ToSorter(genomeSorterOrbit.KeyCount);
        //}

    }

    public class GenomeSorterOrbitImpl : IGenomeSorterOrbit
    {
        public GenomeSorterOrbitImpl(Guid guid, 
            IGenome genome, int keyCount, int permutationCount)
        {
            _genome = genome;
            _keyCount = keyCount;
            _permutationCount = permutationCount;
            _guid = guid;
        }

        private readonly IGenome _genome;
        public IGenome Genome
        {
            get { return _genome; }
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

        public string EntityName
        {
            get { return "GenomeSorterOrbit"; }
        }

        public IEntity GetPart(Guid key)
        {
            if (key == Guid)
            {
                return this;
            }
            return Genome.GetPart(key);
        }

        private readonly int _permutationCount;
        public int PermutationCount
        {
            get { return _permutationCount; }
        }

        public IReadOnlyList<uint> Sequence
        {
            get { return Genome.Sequence; }
        }

        public int SequenceLength
        {
            get { return Genome.SequenceLength; }
        }

        public uint SymbolCount
        {
            get { return Genome.SymbolCount; }
        }

        public PhenotyperSorterType GenomeSorterType
        {
            get { return PhenotyperSorterType.Orbit; }
        }

    }
}
