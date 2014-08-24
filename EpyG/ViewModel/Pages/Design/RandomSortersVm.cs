using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using EpyG.ViewModel.Content;
using FirstFloor.ModernUI.Presentation;
using MathUtils.Collections;
using MathUtils.Rand;
using SorterGenome;
using SorterGenome.Reporting;
using Sorting.Evals;
using Sorting.Sorters;

namespace EpyG.ViewModel.Pages.Design
{
    [Export]
    public class RandomSortersVm : NotifyPropertyChanged
    {
        public RandomSortersVm()
        {
            RandomSorterSettingsVm = new RandomSorterSettingsVm();
        }

        public RandomSorterSettingsVm RandomSorterSettingsVm { get; set; }


        private SortResultReport _sortResultReport = new SortResultReport();
        private SortResultReport SortResultReport
        {
            get { return _sortResultReport; }
            set { _sortResultReport = value; }
        }


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


        #region RandGenCommand

        RelayCommand _randGenCommand;

        public ICommand RandGenCommand
        {
            get
            {
                return _randGenCommand ?? (_randGenCommand
                    = new RelayCommand
                        (
                            param => OnRandGenCommand(),
                            param => CanRandGenCommand()
                        ));
            }
        }

        bool CanRandGenCommand()
        {
            return !_busy;
        }

        private CancellationTokenSource _cancellationTokenSource;

        readonly Stopwatch _stopwatch = new Stopwatch();

        async Task OnRandGenCommand()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Busy = true;
            _stopwatch.Start();

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await Task.Run(() => NextRound());
                Tuple<IList<ISortResult>, ImmutableStack<ISorter>> result = null;
                await Task.Run(() => result = ProcessStack(_sorterStack));
                ElapsedTime = _stopwatch.Elapsed;
                await Task.Run(() => SortResultReport.AddSorterEvals(result.Item1.Select(r => r.ToSorterEval())));
                OnPropertyChanged("Report");
                _sorterStack = result.Item2;
            }

            Busy = false;
            _stopwatch.Stop();
            CommandManager.InvalidateRequerySuggested();
        }


        #endregion // RandGenCommand


        Tuple<IList<ISortResult>, ImmutableStack<ISorter>> ProcessStack(ImmutableStack<ISorter> sorterStack)
        {
            var sortResults = new List<ISortResult>();
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var sorterChunk = sorterStack.PopAChunk(ChunkSize);
                sorterStack = sorterChunk.Item2;


                if (! sorterChunk.Item1.Any())
                {
                    break;
                }

                var results = sorterChunk.Item1.AsParallel().Select(s => s.FullTest());

                sortResults.AddRange(results);
            }

            return new Tuple<IList<ISortResult>, ImmutableStack<ISorter>>(sortResults, sorterStack);
        }

        void NextRound()
        {
            if (! _sorterStack.Any())
            {
                _sorterStack = ImmutableStack<ISorter>.Empty.PushMany(RandomSorters());
            }

            _cancellationTokenSource = new CancellationTokenSource();
        }


        #region StopRandGenCommand

        RelayCommand _stopRandGenCommand;
        public ICommand StopRandGenCommand
        {
            get
            {
                return _stopRandGenCommand ?? (_stopRandGenCommand
                    = new RelayCommand
                        (
                            param => OnStopRandGenCommand(),
                            param => CanStopRandGenCommand()
                        ));
            }
        }

        protected void OnStopRandGenCommand()
        {
            _cancellationTokenSource.Cancel();
        }

        bool CanStopRandGenCommand()
        {
            return _busy;
        }

        #endregion // StopRandGenCommand

        #region ResetCommand

        RelayCommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand
                    = new RelayCommand
                        (
                            param => OnResetCommand(),
                            param => CanResetCommand()
                        ));
            }
        }

        protected void OnResetCommand()
        {
            _randy = Rando.Fast(RandomSorterSettingsVm.Seed.Value);
            _sorterStack.Clear();
            _stopwatch.Reset();
            ElapsedTime = _stopwatch.Elapsed;
            SortResultReport = new SortResultReport();
            OnPropertyChanged("Report");
        }

        bool CanResetCommand()
        {
            return !_busy;
        }

        #endregion // ResetCommand

        private IRando _randy;
        IRando Randy
        {
            get
            {
              return  _randy ?? (_randy = Rando.Fast(RandomSorterSettingsVm.Seed.Value));
            }
        }

        private ImmutableStack<ISorter> _sorterStack = ImmutableStack.Create<ISorter>();
        private const int ChunkSize  = 16;


        IEnumerable<IGenomeSorter> RandomGenomeSorters()
        {
            var counts = Enumerable.Range(0, RandomSorterSettingsVm.ReportFrequency.Value);

            switch (RandomSorterSettingsVm.GenomeSorterType)
            {
                case PhenotyperSorterType.Index:
                    return counts.Select
                        (
                            _ => Randy.ToGenomeSorterIndex
                            (
                                keyCount: RandomSorterSettingsVm.SuggestedKeyParam.KeyCount,
                                sequenceLength: RandomSorterSettingsVm.TotalSwitchCount.Value
                            )
                        );
                case PhenotyperSorterType.Permutation:
                    return counts.Select
                        (
                            _ => Randy.ToGenomeSorterPermutation
                            (
                                keyCount: RandomSorterSettingsVm.SuggestedKeyParam.KeyCount,
                                permutationCount: 2 * RandomSorterSettingsVm.TotalSwitchCount.Value
                                                        / RandomSorterSettingsVm.SuggestedKeyParam.KeyCount
                            )
                        );
                case PhenotyperSorterType.PermuSort:
                    return counts.Select
                        (
                            _ => Randy.ToGenomeSorterPermuSort
                            (
                                keyCount: RandomSorterSettingsVm.SuggestedKeyParam.KeyCount,
                                permutationCount: 22 * RandomSorterSettingsVm.TotalSwitchCount.Value
                                                        / RandomSorterSettingsVm.SuggestedKeyParam.KeyCount
                            )
                        );

                case PhenotyperSorterType.Orbit:
                    return counts.Select
                        (
                            _ => Randy.ToGenomeSorterOrbit
                            (
                                keyCount: RandomSorterSettingsVm.SuggestedKeyParam.KeyCount,
                                permutationCount: 2 * RandomSorterSettingsVm.TotalSwitchCount.Value
                                                        / RandomSorterSettingsVm.SuggestedKeyParam.KeyCount
                            )
                        );
                default:
                    throw new ArgumentException(String.Format("{0} not handled", RandomSorterSettingsVm.GenomeSorterType));
            }
        }

        IReadOnlyList<ISorter> RandomSorters()
        {
                var genomes = RandomGenomeSorters();

                return genomes.Select(g => g.ToSorter()).ToList();
        }

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

        public string Report
        {
            get { return SortResultReport.Report; }
        }
    }
}
