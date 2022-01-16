using System;

namespace PracticeManagement.Core.Helpers
{
    public class Range<T> where T : IComparable
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; private set; }
        public T Max { get; private set; }

        public bool IsOverlapped(Range<T> other)
        {
            return Min.CompareTo(other.Max) < 0 && other.Min.CompareTo(Max) < 0;
        }
    }
}
