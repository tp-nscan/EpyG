using System;
using Sorting.Switchables;

namespace SorterGenome.Config.Evaluator
{
    public interface ISorterEvaluatorConfig : ISwitchable
    {
        SorterEvaluatorConfigType SorterEvaluatorConfigType { get; }
    }

    public static class SorterEvaluatorConfig
    {
    }


    public class SorterEvaluatorConfigFull : ISorterEvaluatorConfig
    {
        public SorterEvaluatorConfigFull(int keyCount, Type switchableDataType)
        {
            _keyCount = keyCount;
            _switchableDataType = switchableDataType;
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly Type _switchableDataType;
        public Type SwitchableDataType
        {
            get { return _switchableDataType; }
        }

        public SorterEvaluatorConfigType SorterEvaluatorConfigType
        {
            get { return SorterEvaluatorConfigType.Full; }
        }
    }




}
