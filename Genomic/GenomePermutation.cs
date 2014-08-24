using System;
using System.Collections.Generic;
using System.Linq;
using MathUtils.Collections;
using MathUtils.Rand;

namespace Genomic
{
    public interface IPermutationEncoding
    {
        int Degree { get; }
        int PermutationCount { get; }
    }

    public interface IGenomePermutation : IGenome, IPermutationEncoding
    {
        
    }

    public static class GenomePermutation
    {
        public static IGenomePermutation ToPermutationGenome
        (
            this IRando randy, 
            int degree, 
            int permutationCount
        )
        {
            return new GenomePermutationImpl(
                    guid: randy.NextGuid(),
                    sequence: randy.ToPermutations(degree)
                                   .Take(permutationCount)
                                   .SelectMany(p => p.Values.Cast<uint>())
                                   .ToList(),
                    degree: degree
                );
        }

        public static IGenomePermutation Make
        (
            Guid guid,
            IReadOnlyList<uint> sequence,
            int degree
        )
        {
            return new GenomePermutationImpl
                (
                    guid: guid, 
                    sequence: sequence, 
                    degree: degree
                );
        }

        public static IGenomePermutation Mutate
            (
                this IGenomePermutation genomePermutation,
                IRando randy,
                double deletionRate,
                double insertionRate,
                double mutationRate
            )
        {
            var degree = genomePermutation.Degree;

            return new GenomePermutationImpl
                (
                    guid: randy.NextGuid(),
                    sequence: genomePermutation
                                .Sequence
                                .ToPermutations(degree)
                                .ToList()
                                .Mutate
                                (
                                    randy: randy,
                                    degree: genomePermutation.Degree,
                                    deletionRate: deletionRate,
                                    insertionRate: insertionRate,
                                    mutationRate: mutationRate
                                ).ToList(),
                    degree: genomePermutation.Degree
                );
        }

        public static IReadOnlyList<uint> Mutate
        (
            this IReadOnlyList<IPermutation> permutations,
            IRando randy,
            int degree,
            double deletionRate,
            double insertionRate,
            double mutationRate
        )
        {
            return permutations
                    .MutateInsertDelete
                    (
                        doMutation: randy.ToBoolEnumerator(mutationRate),
                        doInsertion: randy.ToBoolEnumerator(insertionRate),
                        doDeletion: randy.ToBoolEnumerator(deletionRate),
                        mutator: p => p.Mutate(randy, mutationRate),
                        inserter: x => randy.ToPermutations(degree).First(),
                        paddingFunc: x => randy.ToPermutations(degree).First()
                    )
                    .SelectMany(p => p.Values.Cast<uint>())
                    .ToList();
        }
    }

    public class GenomePermutationImpl : SimpleGenome, IGenomePermutation
    {
        public GenomePermutationImpl
            (
                Guid guid, 
                IReadOnlyList<uint> sequence, 
                int degree
            )
            : base
            (
                guid: guid,
                sequence: sequence,
                symbolCount: (uint) degree
            )
        {
            _degree = degree;
            _permutationCount = SequenceLength/Degree;
        }

        private readonly int _degree;
        public int Degree
        {
            get { return _degree; }
        }

        public override string EntityName
        {
            get { return "PermutationGenome"; }
        }

        private readonly int _permutationCount;
        public int PermutationCount
        {
            get { return _permutationCount; }
        }
    }
}
