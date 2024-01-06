using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
    [Serializable]
    public struct intrange3 : IEquatable<intrange3>
    {
        public int3 min;
        public int3 max;

        public static readonly intrange3 Zero;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public intrange3(int3 min, int3 max)
        {
            this.min = min;
            this.max = max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public intrange3(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
        {
            this.min = new int3(minX, minY, minZ);
            this.max = new int3(maxX, maxY, maxZ);
        }

        public float3 Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return mathx.mul(max + min, 0.5f); }
        }

        public int3 Extents
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return max - min; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(int x, int y, int z)
        {
            return (
                min.x <= x &&
                min.y <= y &&
                min.z <= z &&
                x <= max.x &&
                y <= max.y &&
                z <= max.z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(int3 v)
        {
            return Contains(v.x, v.y, v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(intrange3 other)
        {
            return (
                (min <= other.min).All() &&
                (other.max <= max).All()
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(intrange3 other)
        {
            return (
                (min <= other.max).All() &&
                (other.min <= max).All()
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public intrange3 Intersection(intrange3 other)
        {
            return new intrange3(
                math.max(min, other.min),
                math.min(max, other.max)
            );
        }

        public bool Equals(intrange3 other)
        {
            return (
                (min == other.min).All() &&
                (max == other.max).All()
            );
        }

        public override bool Equals(object obj)
        {
            return obj is intrange3 && Equals((intrange3)obj);
        }

        public override int GetHashCode()
        {
            return min.GetHashCode() ^ (max.GetHashCode() << 2);
        }

        public override string ToString()
        {
            return string.Format("intrange3({0}, {1})", min, max);
        }
    }
}