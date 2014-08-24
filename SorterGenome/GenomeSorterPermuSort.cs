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
    public interface IGenomeSorterPermuSort : IGenomeSorter, IGenomePermutation
    {
        IGenomePermutation GenomePermutation { get; }
    }

    public static class GenomeSorterPermuSort
    {
        public static IGenomeSorterPermuSort ToGenomeSorterPermuSort
        (
            this IRando randy,
            int permutationCount,
            int keyCount
        )
        {
            return new GenomeSorterPermuSortImpl(
                    guid: randy.NextGuid(),
                    genomePermutation: randy.ToPermutationGenome
                    (
                        degree: keyCount,
                        permutationCount: permutationCount
                    ),
                    keyCount: keyCount
                );
        }

        public static IGenomeSorterPermuSort Make
        (
            Guid outerGuid,
            Guid innerGuid,
            IReadOnlyList<uint> sequence,
            int keyCount
        )
        {
            return new GenomeSorterPermuSortImpl
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

        public static IGenomeSorterPermuSort Mutate
            (
                this IGenomeSorterPermuSort genomeSorterPermuSort,
                IRando randy,
                double deletionRate,
                double insertionRate,
                double mutationRate,
                int keyCount
            )
        {
            return new GenomeSorterPermuSortImpl
                (
                    guid: randy.NextGuid(),
                    genomePermutation: 
                        genomeSorterPermuSort
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

        //public static ISorter ToSorter(this IGenomePermuSortSorter genomePermutationSorter)
        //{
        //    var dblChunks = genomePermutationSorter.Sequence.Chunk(genomePermutationSorter.Degree).Chunk(2);

        //    var convertedSequence = new List<uint>();

        //    foreach (var dblChunk in dblChunks)
        //    {
        //        var convertedChunk = dblChunk[0].Select(v => (int) v).ToArray();
        //        convertedSequence.AddRange(
                    
        //                dblChunk[1].ToKeyPairs().ToSorter(genomePermutationSorter.Degree)
        //                                        .Sort(convertedChunk)
        //                                        .Select(v=>(uint)v)
        //            );
        //    }

        //    return convertedSequence.ToKeyPairs().ToSorter(genomePermutationSorter.Degree);
        //}


        //public static ISorter ToSorter(this IGenomePermuSortSorter genomePermutationSorter)
        //{
        //    var dblChunks = genomePermutationSorter.Sequence.Chunk(genomePermutationSorter.Degree).Chunk(7);

        //    var convertedSequence = new List<uint>();

        //    foreach (var dblChunk in dblChunks)
        //    {
        //        var convertedChunk = dblChunk[0].Select(v => (int)v).ToArray();
        //        convertedSequence.AddRange(

        //                dblChunk[1].Concat(dblChunk[2])
        //                           .Concat(dblChunk[3])
        //                           .Concat(dblChunk[4])
        //                           .Concat(dblChunk[5])
        //                           .Concat(dblChunk[6])
        //                           .ToArray()
        //                    .ToKeyPairs().ToSorter(genomePermutationSorter.Degree)
        //                                            .Sort(convertedChunk)
        //                                            .Select(v => (uint)v)
        //            );
        //    }

        //    return convertedSequence.ToKeyPairs().ToSorter(genomePermutationSorter.Degree);
        //}

        public static ISorter ToSorter(this IGenomeSorterPermuSort genomeSorterPermutation)
        {
            var dblChunks = genomeSorterPermutation.Sequence.Chunk(genomeSorterPermutation.Degree).Chunk(11);

            var convertedSequence = new List<uint>();

            foreach (var dblChunk in dblChunks)
            {
                var convertedChunk = dblChunk[0].Select(v => (int)v).ToArray();
                convertedSequence.AddRange(

                        dblChunk[5].Concat(dblChunk[6])
                                   .Concat(dblChunk[7])
                                   .Concat(dblChunk[8])
                                   .Concat(dblChunk[9])
                                   .Concat(dblChunk[10])
                                   .ToArray()
                            .ToKeyPairs().ToSorter(genomeSorterPermutation.Degree)
                                             .Sort(convertedChunk)
                                             .Select(v => (uint)v)
                    );


               convertedChunk = dblChunk[1].Select(v => (int)v).ToArray();
                convertedSequence.AddRange(


                        dblChunk[5].Concat(dblChunk[6])
                                   .Concat(dblChunk[7])
                                   .Concat(dblChunk[8])
                                   .Concat(dblChunk[9])
                                   .Concat(dblChunk[10])
                                   .ToArray()
                            .ToKeyPairs().ToSorter(genomeSorterPermutation.Degree)
                                            .Sort(convertedChunk)
                                            .Select(v => (uint)v)
                    );

                convertedChunk = dblChunk[2].Select(v => (int)v).ToArray();
                convertedSequence.AddRange(


                        dblChunk[5].Concat(dblChunk[6])
                                   .Concat(dblChunk[7])
                                   .Concat(dblChunk[8])
                                   .Concat(dblChunk[9])
                                   .Concat(dblChunk[10])
                                   .ToArray()
                            .ToKeyPairs().ToSorter(genomeSorterPermutation.Degree)
                                            .Sort(convertedChunk)
                                            .Select(v => (uint)v)
                    );

                convertedChunk = dblChunk[3].Select(v => (int)v).ToArray();
                convertedSequence.AddRange(


                        dblChunk[5].Concat(dblChunk[6])
                                   .Concat(dblChunk[7])
                                   .Concat(dblChunk[8])
                                   .Concat(dblChunk[9])
                                   .Concat(dblChunk[10])
                                   .ToArray()
                            .ToKeyPairs().ToSorter(genomeSorterPermutation.Degree)
                                            .Sort(convertedChunk)
                                            .Select(v => (uint)v)
                    );

                convertedChunk = dblChunk[4].Select(v => (int)v).ToArray();
                convertedSequence.AddRange(


                        dblChunk[5].Concat(dblChunk[6])
                                   .Concat(dblChunk[7])
                                   .Concat(dblChunk[8])
                                   .Concat(dblChunk[9])
                                   .Concat(dblChunk[10])
                                   .ToArray()
                            .ToKeyPairs().ToSorter(genomeSorterPermutation.Degree)
                                            .Sort(convertedChunk)
                                            .Select(v => (uint)v)
                    );
            }

            return convertedSequence.ToKeyPairs().ToSorter(genomeSorterPermutation.Degree);
        }

    }

    public class GenomeSorterPermuSortImpl : IGenomeSorterPermuSort
    {
        public GenomeSorterPermuSortImpl(Guid guid, IGenomePermutation genomePermutation, int keyCount)
        {
            _guid = guid;
            _genomePermutation = genomePermutation;
            _keyCount = keyCount;
        }

        public string EntityName
        {
            get { return "GenomePermuSortSorter"; }
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
            get { return PhenotyperSorterType.PermuSort; }
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly IGenomePermutation _genomePermutation;
        public IGenomePermutation GenomePermutation
        {
            get { return _genomePermutation; }
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
