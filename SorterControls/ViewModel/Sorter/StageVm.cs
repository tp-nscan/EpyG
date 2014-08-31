using System.Collections.Generic;
using System.Windows.Media;

namespace SorterControls.ViewModel.Sorter
{
    public class StageVm
    {
        public StageVm
            (
                int keyCount, 
                IReadOnlyList<KeyPairVm> keyPairVms, 
                double switchWidth,
                double lineThickness, 
                Brush lineBrush, 
                Brush backgroundBrush
            )
        {
            _keyCount = keyCount;
            _keyPairVms = keyPairVms;
            _switchWidth = switchWidth;
            _lineThickness = lineThickness;
            _lineBrush = lineBrush;
            _backgroundBrush = backgroundBrush;
        }

        private readonly IReadOnlyList<KeyPairVm> _keyPairVms;
        public IReadOnlyList<KeyPairVm> KeyPairVms
        {
            get { return _keyPairVms; }
        }

        private readonly Brush _lineBrush;
        public Brush LineBrush
        {
            get { return _lineBrush; }
        }

        private readonly int _keyCount;
        public int KeyCount
        {
            get { return _keyCount; }
        }

        private readonly double _switchWidth;
        public double SwitchWidth
        {
            get { return _switchWidth; }
        }

        private readonly double _lineThickness;
        public double LineThickness
        {
            get { return _lineThickness; }
        }

        private readonly Brush _backgroundBrush;
        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
        }
    }
}
