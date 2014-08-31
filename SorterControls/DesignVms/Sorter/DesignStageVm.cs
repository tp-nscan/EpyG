using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using SorterControls.ViewModel.Sorter;
using Sorting.KeyPairs;

namespace SorterControls.DesignVms.Sorter
{
    public class DesignStageVm : StageVm
    {
        public DesignStageVm()
            : base
                (
                    keyCount: _keyCount,
                    keyPairVms: KeyPairVms.ToList(),
                    switchWidth: _switchWidth,
                    lineThickness: _lineThickness,
                    lineBrush: _lineBrush,
                    backgroundBrush: _backgroundBrush
               )
        {
        }

        public const int _keyCount = 8;
        private const double _switchWidth = 0.3;
        private const double _lineThickness = 0.07;
        private static readonly Brush _lineBrush = new SolidColorBrush(Colors.Black);
        private static readonly Brush _backgroundBrush = new SolidColorBrush(Colors.WhiteSmoke);


        public static IEnumerable<KeyPairVm> KeyPairVms
        {
           get
           {
               yield return
                   new KeyPairVm()
                   {
                       KeyPair = KeyPairRepository.KeyPairFromKeys(0, 1),
                       Position = 0,
                       SwitchBrush = new SolidColorBrush(Colors.Olive)
                   };

               yield return
                    new KeyPairVm()
                    {
                        KeyPair = KeyPairRepository.KeyPairFromKeys(3, 7),
                        Position = 0,
                        SwitchBrush = new SolidColorBrush(Colors.SeaGreen)
                    };

               yield return
                   new KeyPairVm()
                   {
                       KeyPair = KeyPairRepository.KeyPairFromKeys(1, 2),
                       Position = 1,
                       SwitchBrush = new SolidColorBrush(Colors.OrangeRed)
                   };

               yield return
                    new KeyPairVm()
                    {
                        KeyPair = KeyPairRepository.KeyPairFromKeys(5, 6),
                        Position = 1,
                        SwitchBrush = new SolidColorBrush(Colors.SlateBlue)
                    };

               yield return
                   new KeyPairVm()
                   {
                       KeyPair = KeyPairRepository.KeyPairFromKeys(3, 7),
                       Position = 2,
                       SwitchBrush = new SolidColorBrush(Colors.PaleVioletRed)
                   };

               yield return
                   new KeyPairVm()
                   {
                       KeyPair = KeyPairRepository.KeyPairFromKeys(0, 4),
                       Position = 3,
                       SwitchBrush = new SolidColorBrush(Colors.Orchid)
                   };

               yield return
                    new KeyPairVm()
                    {
                        KeyPair = KeyPairRepository.KeyPairFromKeys(1, 5),
                        Position = 4,
                        SwitchBrush = new SolidColorBrush(Colors.Navy)
                    };

               yield return
                     new KeyPairVm()
                     {
                         KeyPair = KeyPairRepository.KeyPairFromKeys(2, 6),
                         Position = 5,
                         SwitchBrush = new SolidColorBrush(Colors.SaddleBrown)
                     };


           }
        }
    }
}
