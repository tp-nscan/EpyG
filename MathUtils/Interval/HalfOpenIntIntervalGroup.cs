using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtils.Interval
{
    public interface IHalfOpenIntIntervalGroup
    {
        IEnumerable<IHalfOpenIntInterval> HalfOpenIntIntervals { get; }
    }

    public static class HalfOpenIntIntervalGroup
    {
        public static IHalfOpenIntIntervalGroup Make()
        {
            return new HalfOpenIntIntervalGroupImpl();
        }
    }

    public class HalfOpenIntIntervalGroupImpl : IHalfOpenIntIntervalGroup
    {
        public HalfOpenIntIntervalGroupImpl()
        {
            _halfOpenIntIntervals = ImmutableList<IHalfOpenIntInterval>.Empty;
        }

        HalfOpenIntIntervalGroupImpl(ImmutableList<IHalfOpenIntInterval> halfOpenIntIntervals)
        {
            _halfOpenIntIntervals = halfOpenIntIntervals;
        }

        public IHalfOpenIntIntervalGroup Add(IHalfOpenIntInterval interval)
        {
            var dex = _halfOpenIntIntervals.FindIndex(h => interval.Max < h.Min);
            if (dex == -1)
            {
                if (_halfOpenIntIntervals.Last().AdjacentOrOverlap(interval))
                {
                    var newList = _halfOpenIntIntervals.RemoveAt(_halfOpenIntIntervals.Count - 1);
                    return new HalfOpenIntIntervalGroupImpl(newList.Add(_halfOpenIntIntervals.Last().Merge(interval)));
                }
                return new HalfOpenIntIntervalGroupImpl(_halfOpenIntIntervals.Add(interval));
            }

            if (dex == 0)
            {
                return new HalfOpenIntIntervalGroupImpl(_halfOpenIntIntervals.Insert(0, interval));
            }

            if (_halfOpenIntIntervals.Last().AdjacentOrOverlap(interval))
            {
                var newList = _halfOpenIntIntervals.RemoveAt(_halfOpenIntIntervals.Count - 1);
                return new HalfOpenIntIntervalGroupImpl(newList.Add(_halfOpenIntIntervals.Last().Merge(interval)));
            }
            return new HalfOpenIntIntervalGroupImpl(_halfOpenIntIntervals.Add(interval));
        }

        private readonly ImmutableList<IHalfOpenIntInterval> _halfOpenIntIntervals;
        public IEnumerable<IHalfOpenIntInterval> HalfOpenIntIntervals
        {
            get { return _halfOpenIntIntervals; }
        }
    }
}