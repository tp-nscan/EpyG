using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Sorting.KeyPairs;

namespace SorterControls.ViewModel.Sorter
{
    public interface ISorterVm
    {
        int KeyCount { get; }
        IReadOnlyList<StageVm> StageVms { get; }
    }

    public static class SorterVm
    {
        public const int _keyCount = 8;
        private const double _switchWidth = 0.3;
        private const double _lineThickness = 0.07;
        private static readonly Brush _lineBrush = new SolidColorBrush(Colors.Black);
        private static readonly Brush _backgroundBrush = new SolidColorBrush(Colors.WhiteSmoke);

        public static ISorterVm Make
            (
                int keyCount,
                IReadOnlyList<StageVm> stageVms
            )
        {
            return new SorterVmImpl
                (
                    keyCount: keyCount,
                    stageVms: stageVms
                );
        }

        //public static ISorterVm MakeUnstaged
        //    (
        //        int keyCount,
        //        IReadOnlyList<IKeyPair> keyPairs
        //    )
        //{
        //    return new SorterVmImpl
        //        (
        //            keyCount: keyCount,
        //            stageVms: keyPairs.Select(

        //                    kp => new KeyPairVm()
        //                    {
        //                        KeyPair = KeyPairRepository.KeyPairFromKeys(0, 1),
        //                        Position = 0,
        //                        SwitchBrush = new SolidColorBrush(Colors.Olive)
        //                    }


        //                ).ToList()
        //        );


        //}
    }


    public class SorterVmImpl : ISorterVm
    {
        public SorterVmImpl
            (
                int keyCount, 
                IReadOnlyList<StageVm> stageVms
            )
        {
            _keyCount = keyCount;
            _stageVms = stageVms;
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly IReadOnlyList<StageVm> _stageVms;
        public IReadOnlyList<StageVm> StageVms
        {
            get { return _stageVms; }
        }
    }
}
