using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MathUtils.Collections;

namespace MathUtils.Interval
{
    public interface IHalfOpenIntIntervalGroup<T>
    {
        IEnumerable<IHalfOpenIntInterval<T>> HalfOpenIntIntervals { get; }
        IHalfOpenIntIntervalGroup<T> Add<T>(IHalfOpenIntInterval<T> interval, Func<T, T, T> mergeFunc);
    }

    public static class HalfOpenIntIntervalGroup
    {
             public static IEnumerable<Tuple<int, int>> ToUncoveredSpans<T>
            (
                this IHalfOpenIntIntervalGroup<T> halfOpenIntIntervalGroup,
                int lowerBound,
                int upperBound
            )
        {
                if (! halfOpenIntIntervalGroup.HalfOpenIntIntervals.Any())
                {
                    yield return new Tuple<int, int>(lowerBound, upperBound);
                }

                 var groupLowerBound = halfOpenIntIntervalGroup.HalfOpenIntIntervals.First().Min;
                 if (lowerBound < groupLowerBound)
                 {
                     yield return new Tuple<int, int>(lowerBound, groupLowerBound);
                 }


                 foreach (var tuple in halfOpenIntIntervalGroup.HalfOpenIntIntervals
                                            .ToGapResults((f,s) => new Tuple<int,int>(f.Max, s.Min)))
                 {
                     yield return tuple;
                 }
                 
                 var groupUpperBound = halfOpenIntIntervalGroup.HalfOpenIntIntervals.Last().Max;
                 if (upperBound > groupLowerBound)
                 {
                     yield return new Tuple<int, int>(groupUpperBound, upperBound);
                 }
        }

        public static IEnumerable<IHalfOpenIntInterval<T>> ToPatches<T>
            (
                this IHalfOpenIntIntervalGroup<T> halfOpenIntIntervalGroup,
                int lowerBound,
                int upperBound, 
                int span, 
                T payload
            )
        {
            return halfOpenIntIntervalGroup
                .ToUncoveredSpans(lowerBound, upperBound)
                .SelectMany(tuple => HalfOpenIntInterval.SpanRange(tuple.Item1, tuple.Item2, span, payload));
        }


        public static IHalfOpenIntIntervalGroup<T> Make<T>()
        {
            return new HalfOpenIntIntervalGroupImpl<T>();
        }

        public static IEnumerable<IHalfOpenIntInterval<T>> PatchIn<T>
        (
            IList<IHalfOpenIntInterval<T>> intervals,
            IHalfOpenIntInterval<T> rhs, Func<T, T, T> mergeFunc)
        {
            var wasAdded = false;
            foreach (var halfOpenIntInterval in intervals)
            {
                if (wasAdded)
                {
                    yield return halfOpenIntInterval;
                    continue;
                }
                if (rhs.Max < halfOpenIntInterval.Min)
                {
                    yield return rhs;
                    wasAdded = true;
                    yield return halfOpenIntInterval;
                    continue;
                }
                if (rhs.AdjacentOrOverlap(halfOpenIntInterval))
                {
                    rhs = rhs.Merge(halfOpenIntInterval, mergeFunc);
                    continue;
                }
                yield return halfOpenIntInterval;
            }
            if (wasAdded == false)
            {
                yield return rhs;
            }
        }
    }

    public class HalfOpenIntIntervalGroupImpl<T> : IHalfOpenIntIntervalGroup<T>
    {
        public HalfOpenIntIntervalGroupImpl()
        {
            _halfOpenIntIntervals = ImmutableList<IHalfOpenIntInterval<T>>.Empty;
        }

        HalfOpenIntIntervalGroupImpl(IList<IHalfOpenIntInterval<T>> halfOpenIntIntervals)
        {
            _halfOpenIntIntervals = halfOpenIntIntervals;
        }

        public IHalfOpenIntIntervalGroup<T> Add<T>(IHalfOpenIntInterval<T> interval, Func<T, T, T> mergeFunc)
        {
            var newList = new List<IHalfOpenIntInterval<T>>();

            var wasAdded = false;
            foreach (IHalfOpenIntInterval<T> halfOpenIntInterval in _halfOpenIntIntervals)
            {
                if (wasAdded)
                {
                    newList.Add(halfOpenIntInterval);
                    continue;
                }
                if (interval.Max < halfOpenIntInterval.Min)
                {
                    newList.Add(interval);
                    wasAdded = true;
                    newList.Add(halfOpenIntInterval);
                    continue;
                }
                if (interval.AdjacentOrOverlap(halfOpenIntInterval))
                {
                    interval = interval.Merge(halfOpenIntInterval, mergeFunc);
                    continue;
                }
                newList.Add(halfOpenIntInterval);
            }
            if (wasAdded == false)
            {
                newList.Add(interval);
            }
            return new HalfOpenIntIntervalGroupImpl<T>(newList);
        }

        private readonly IList<IHalfOpenIntInterval<T>> _halfOpenIntIntervals;
        public IEnumerable<IHalfOpenIntInterval<T>> HalfOpenIntIntervals
        {
            get { return _halfOpenIntIntervals; }
        }
    }
}