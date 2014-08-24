using System;
using System.Collections.Generic;
using System.Linq;
using MathUtils;
using MathUtils.Collections;
using MathUtils.Rand;

namespace Genomic
{
    public interface IGenome : IEntity
    {
        IReadOnlyList<uint> Sequence { get; }
        int SequenceLength { get; }
        uint SymbolCount { get; }
    }

    public static class Genome
    {
        public static IGenome ToGenome
            (
                this IRando randy,
                uint symbolCount,
                int sequenceLength
            )
        {
            return new SimpleGenome(
                guid: randy.NextGuid(),
                sequence: Enumerable.Range(0, sequenceLength)
                                    .Select(i => randy.NextUint(symbolCount))
                                    .ToList(),
                symbolCount: symbolCount
            );
        }

        public static IGenome Make
            (
                Guid guid,
                IReadOnlyList<uint> sequence, 
                uint symbolCount
            )
        {
            return new SimpleGenome(
                    guid: guid,
                    sequence: sequence, 
                    symbolCount: symbolCount
                );
        }


        public static IGenome Mutate
        (
            this IGenome genome,
            IRando randy,
            double deletionRate,
            double insertionRate,
            double mutationRate
        )
        {
            var symbolCount = genome.SymbolCount;

            return new SimpleGenome
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
                );
        }

        public static IReadOnlyList<uint> Mutate
        (
            this IReadOnlyList<uint> sequence,
            IRando randy,
            uint symbolCount,
            double deletionRate,
            double insertionRate,
            double mutationRate
        )
        {
            return sequence
                    .MutateInsertDelete
                    (
                        doMutation: randy.ToBoolEnumerator(mutationRate),
                        doInsertion: randy.ToBoolEnumerator(insertionRate),
                        doDeletion: randy.ToBoolEnumerator(deletionRate),
                        mutator: x => randy.NextUint(symbolCount),
                        inserter: x => randy.NextUint(symbolCount),
                        paddingFunc: x => randy.NextUint(symbolCount)
                    ).ToList();
        }

    }

    public class SimpleGenome : IGenome
    {
        public SimpleGenome
        (
            Guid guid,
            IReadOnlyList<uint> sequence, 
            uint symbolCount
        )
        {
            _sequence = sequence;
            _symbolCount = symbolCount;
            _symbolCount = symbolCount;
            _guid = guid;
        }

        private readonly IReadOnlyList<uint> _sequence;
        public IReadOnlyList<uint> Sequence
        {
            get { return _sequence; }
        }

        public int SequenceLength
        {
            get { return _sequence.Count; }
        }

        private readonly uint _symbolCount;
        public uint SymbolCount
        {
            get { return _symbolCount; }
        }

        public virtual string EntityName
        {
            get { return "SimpleGenome"; }
        }

        public IEntity GetPart(Guid key)
        {
            if (key == Guid)
            {
                return this;
            }
            return null;
        }

        private readonly Guid _guid;
        public Guid Guid
        {
            get { return _guid; }
        }
    }
}
