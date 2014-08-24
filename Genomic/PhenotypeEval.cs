using System;
using MathUtils;

namespace Genomic
{
    public interface IPhenotypeEval : IEntity
    {
        IComparable Result { get; }
        IPhenotype Phenotype { get; }
    }

    public abstract class PhenotypeEvalBase : IPhenotypeEval
    {
        protected PhenotypeEvalBase(
                Guid guid,
                IComparable result, 
                IPhenotype phenotype
            )
        {
            _guid = guid;
            _result = result;
            _phenotype = phenotype;
        }

        public abstract string EntityName { get; }
        public abstract IEntity GetPart(Guid key);

        private readonly Guid _guid;
        public Guid Guid
        {
            get { return _guid; }
        }

        // ReSharper disable once InconsistentNaming
        protected readonly IComparable _result;
        public IComparable Result
        {
            get { return _result; }
        }

        private readonly IPhenotype _phenotype;
        public IPhenotype Phenotype
        {
            get { return _phenotype; }
        }
    }
}
