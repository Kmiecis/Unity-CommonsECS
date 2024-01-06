using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
    public struct range
    {
        public float min;
        public float max;

        public static readonly range zero;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (max + min) * 0.5f; }
        }

        public float Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return max - min; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float f)
        {
            return min <= f && f <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(range other)
        {
            return min <= other.min && other.max <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(range other)
        {
            return min <= other.max && other.min <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public range Intersection(range other)
        {
            return new range(
                math.max(min, other.min),
                math.min(max, other.max)
            );
        }

        public bool Equals(range other)
        {
            return (
                mathx.isequal(min, other.min) &&
                mathx.isequal(max, other.max)
            );
        }

        public override bool Equals(object obj)
        {
            return obj is range && Equals((range)obj);
        }

        public override int GetHashCode()
        {
            return min.GetHashCode() ^ (max.GetHashCode() << 2);
        }

        public override string ToString()
        {
            return string.Format("range({0}, {1})", min, max);
        }
    }
}