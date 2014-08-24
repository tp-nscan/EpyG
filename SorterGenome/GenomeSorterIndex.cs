using System;
using System.Collections.Generic;
using System.Linq;
using Genomic;
using MathUtils;
using MathUtils.Rand;
using Sorting.KeyPairs;
using Sorting.Sorters;

namespace SorterGenome
{
    public interface IGenomeSorterIndex : IGenomeSorter
    {
    }

    public static class GenomeSorterIndex
    {
        public static ISorter ToSorter(this IGenomeSorterIndex genomeSorterIndex)
        {
            return genomeSorterIndex.Sequence.Select(i => KeyPairRepository.AtIndex((int) i))
                                .ToSorter(genomeSorterIndex.KeyCount);
        }

        public static IGenomeSorterIndex ToGenomeSorterIndex
        (
            this IRando randy,
            int keyCount,
            int sequenceLength
        )
        {
            return new GenomeSorterIndexImpl
                (
                    guid: randy.NextGuid(),
                    genome: randy.ToGenome
                            (
                                symbolCount: (uint)KeyPairRepository.KeyPairSetSizeForKeyCount(keyCount),
                                sequenceLength: sequenceLength
                            ),
                    keyCount: keyCount
                );
        }

        public static IGenomeSorterIndex Make
        (
            Guid guid,
            Guid innerGuid,
            IReadOnlyList<uint> sequence,
            int keyCount
        )
        {
            return new GenomeSorterIndexImpl
                (
                    guid: guid,
                    genome: Genome.Make
                    (
                        guid: innerGuid,
                        sequence: sequence,
                        symbolCount: (uint)KeyPairRepository.KeyPairSetSizeForKeyCount(keyCount)
                    ),
                    keyCount: keyCount
                );
        }


        public static IGenomeSorterIndex Mutate
            (
                this IGenomeSorter genome,
                IRando randy,
                double deletionRate,
                double insertionRate,
                double mutationRate,
            int keyCount
            )
        {
            var symbolCount = genome.SymbolCount;

            return new GenomeSorterIndexImpl
                (
                    guid: randy.NextGuid(),
                    genome: new SimpleGenome
                    (
                        guid: randy.NextGuid(),
                        sequence: genome.Sequence
                                        .Mutate
                                        (
                                            randy: randy,
                                            symbolCount: symbolCount,
                                            deletionRate: deletionRate,
                                            insertionRate: insertionRate,
                                            mutationRate: mutationRate
                                        ).ToList(),
                        symbolCount: genome.SymbolCount
                    ),
                    keyCount: keyCount
                );
        }
    }

    public class GenomeSorterIndexImpl : IGenomeSorterIndex
    {
        public GenomeSorterIndexImpl(Guid guid, IGenome genome, int keyCount)
        {
            _genome = genome;
            _keyCount = keyCount;
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
            get { return "SorterGenomeIndex"; }
        }

        public IEntity GetPart(Guid key)
        {
            if (key == Guid)
            {
                return this;
            }
            return Genome.GetPart(key);
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
            get { return PhenotyperSorterType.Index; }
        }
    }
}
