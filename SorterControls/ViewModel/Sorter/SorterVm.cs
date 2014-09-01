using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Sorting.Sorters;
using Sorting.Stages;

namespace SorterControls.ViewModel.Sorter
{
    public interface ISorterVm
    {
        int KeyCount { get; }
        IReadOnlyList<IStageVm> StageVms { get; }
    }

    public static class SorterVm
    {
        public const double StandardSwitchWidth = 0.3;
        public const double StandardineThickness = 0.07;

        public static ISorterVm Make
            (
                int keyCount,
                IReadOnlyList<IStageVm> stageVms
            )
        {
            return new SorterVmImpl
                (
                    keyCount: keyCount,
                    stageVms: stageVms
                );
        }

        public static ISorterVm ToStagedSorterVm(
            this ISorter sorter,
            Brush foregroundBrush,
            Brush backgroundBrush
        )
            {
                return new SorterVmImpl
                    (
                        keyCount: sorter.KeyCount,
                        stageVms: sorter.ToStagedSorter().SorterStages.Select
                            (
                                ss => ss.ToStageVm
                                    (
                                        switchWidth: StandardSwitchWidth,
                                        lineThickness: StandardineThickness,
                                        lineBrush: foregroundBrush,
                                        backgroundBrush: backgroundBrush,
                                        switchBrush: foregroundBrush
                                    )
                            ).ToList()
                    );

            }

        public static ISorterVm ToStagedSorterVm(
                this ISorter sorter,
                double switchWidth,
                double lineThickness,
                Brush lineBrush,
                Brush backgroundBrush,
                Brush switchBrush
            )
        {
            return new SorterVmImpl(
                    keyCount: sorter.KeyCount,
                    stageVms: sorter.ToStagedSorter().SorterStages.Select
                        (
                            ss=>ss.ToStageVm
                                (
                                    switchWidth: switchWidth,
                                    lineThickness: lineThickness,
                                    lineBrush:lineBrush,
                                    backgroundBrush: backgroundBrush,
                                    switchBrush: switchBrush
                                )
                        ).ToList()
                );

        }


    }


    public class SorterVmImpl : ISorterVm
    {
        public SorterVmImpl
            (
                int keyCount,
                IReadOnlyList<IStageVm> stageVms
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

        private readonly IReadOnlyList<IStageVm> _stageVms;
        public IReadOnlyList<IStageVm> StageVms
        {
            get { return _stageVms; }
        }
    }
}
