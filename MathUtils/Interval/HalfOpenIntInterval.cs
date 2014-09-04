using System;

namespace MathUtils.Interval
{
    public interface IHalfOpenIntInterval
    {
        int Min { get; }
        int Max { get; }
    }

    public static class HalfOpenIntInterval
    {
        public static IHalfOpenIntInterval Make(int min, int max)
        {
            return new HalfOpenIntIntervalImpl(min, max);
        }

        public static bool AdjacentOrOverlap(this IHalfOpenIntInterval lhs, IHalfOpenIntInterval rhs)
        {
            var newMin = Math.Max(lhs.Min, rhs.Min);
            var newMax = Math.Min(lhs.Max, rhs.Max);
            return (newMin <= newMax);
        }

        public static IHalfOpenIntInterval Merge(this IHalfOpenIntInterval lhs, IHalfOpenIntInterval rhs)
        {
            return Make(Math.Min(lhs.Min, rhs.Min), Math.Max(lhs.Max, rhs.Max));
        }
    }

    class HalfOpenIntIntervalImpl : IHalfOpenIntInterval
    {
        public HalfOpenIntIntervalImpl(int min, int max)
        {
            _min = min;
            _max = max;
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
    }

    
}
