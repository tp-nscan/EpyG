using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;

namespace EpyG.ViewModel.Content
{
    [Export]
    public class EnsembleVm : NotifyPropertyChanged
    {
        private bool _busy;
        public bool Busy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged("Busy");
            }
        }

        #region RunEnsembleCommand

        RelayCommand _runEnsembleCommand;

        public ICommand RunEnsembleCommand
        {
            get
            {
                return _runEnsembleCommand ?? (_runEnsembleCommand
                    = new RelayCommand
                        (
                            param => OnRunEnsembleCommand(),
                            param => CanRunEnsembleCommand()
                        ));
            }
        }

        bool CanRunEnsembleCommand()
        {
            return !_busy;
        }

        private CancellationTokenSource _cancellationTokenSource;

        readonly Stopwatch _stopwatch = new Stopwatch();

        async Task OnRunEnsembleCommand()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Busy = true;
            _stopwatch.Start();

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                //await Task.Run(() => NextRound());
                //Tuple<IList<ISortResult>, ImmutableStack<ISorter>> result = null;
                //await Task.Run(() => result = ProcessStack(_sorterStack));
                ElapsedTime = _stopwatch.Elapsed;
                //await Task.Run(() => SortResultReport.AddSorterEvals(result.Item1.Select(r => r.ToSorterEval())));
                //OnPropertyChanged("Report");
                //_sorterStack = result.Item2;
            }

            Busy = false;
            _stopwatch.Stop();
            CommandManager.InvalidateRequerySuggested();
        }


        #endregion // RunEnsembleCommand


        private TimeSpan _elapsedTime;
        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                _elapsedTime = value;
                OnPropertyChanged("ElapsedTime");
            }
        }
    }
}
