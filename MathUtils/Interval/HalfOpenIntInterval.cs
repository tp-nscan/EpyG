using System;
using System.Collections.Generic;

namespace MathUtils.Interval
{
    public interface IHalfOpenIntInterval<T>
    {
        int Min { get; }
        int Max { get; }
        T Payload { get; }
    }

    public static class HalfOpenIntInterval
    {
        public static IEnumerable<IHalfOpenIntInterval<T>> SpanRange<T>
            (
                int lowerBound, 
                int upperBound, 
                int span, 
                T payload
            )
        {
            var currentUpperBound = lowerBound;
            var currentlowerBound = lowerBound;

            while (currentUpperBound < upperBound)
            {
                currentUpperBound += span;
                if (currentUpperBound > upperBound)
                {
                    currentUpperBound = upperBound;
                }

                yield return Make(currentlowerBound, currentUpperBound, payload);
                currentlowerBound = currentUpperBound;
            }
        }


        public static IHalfOpenIntInterval<T> Make<T>(int min, int max, T payload)
        {
            return new HalfOpenIntIntervalImpl<T>(min, max, payload);
        }

        public static bool AdjacentOrOverlap<T>(this IHalfOpenIntInterval<T> lhs, IHalfOpenIntInterval<T> rhs)
        {
            var newMin = Math.Max(lhs.Min, rhs.Min);
            var newMax = Math.Min(lhs.Max, rhs.Max);
            return (newMin <= newMax);
        }

        public static IHalfOpenIntInterval<T> Merge<T>(this IHalfOpenIntInterval<T> lhs, IHalfOpenIntInterval<T> rhs, Func<T,T,T> mergeFunc)
        {
            return Make(Math.Min(lhs.Min, rhs.Min), Math.Max(lhs.Max, rhs.Max), mergeFunc(lhs.Payload, rhs.Payload));
        }

        public static int Span<T>(this IHalfOpenIntInterval<T> interval)
        {
            return interval.Max - interval.Min;
        }
    }

    class HalfOpenIntIntervalImpl<T> : IHalfOpenIntInterval<T>
    {
        public HalfOpenIntIntervalImpl(int min, int max, T payload)
        {
            _min = min;
            _max = max;
            _payload = payload;
        }

        private readonly int _min;
        public int Min
        {
            get { return _min; }
        }

        private readonly int _max;
        public int Max
        {
            get { return _max; }
        }

        private readonly T _payload;
        public T Payload
        {
            get { return _payload; }
        }
    }

    
}
