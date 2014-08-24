using System;
using MathUtils;

namespace Genomic
{
    public interface IPhenotype : IEntity
    {
        IGenome Genome { get; }
    }

    public abstract class PhenotypeImpl<T> : IPhenotype
    {
        protected PhenotypeImpl
        (
                Guid guid,
                T value, 
                IGenome genome
            )
        {
            _value = value;
            _genome = genome;
            _guid = guid;
        }

        private readonly T _value;
        public T Value
        {
            get { return _value; }
        }

        public abstract string EntityName { get; }

        public abstract IEntity GetPart(Guid key);

        private readonly Guid _guid;

        public Guid Guid
        {
            get { return _guid; }
        }

        readonly IGenome _genome;
        public IGenome Genome
        {
            get { return _genome; }
        }
    }
}
