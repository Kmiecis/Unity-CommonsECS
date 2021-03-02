using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	[Serializable]
	public struct intrange2 : IEquatable<intrange2>
	{
		public int2 min;
		public int2 max;

		public static readonly intrange2 Zero;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public intrange2(int2 min, int2 max)
		{
			this.min = min;
			this.max = max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public intrange2(int minX, int minY, int maxX, int maxY)
		{
			this.min = new int2(minX, minY);
			this.max = new int2(maxX, maxY);
		}

		public float2 Center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return mathx.mul(max + min, 0.5f); }
		}

		public int2 Size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return max - min; }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int x, int y)
		{
			return (
				min.x <= x &&
				min.y <= y &&
				x <= max.x &&
				y <= max.y
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int2 v)
		{
			return Contains(v.x, v.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(intrange2 other)
		{
			return (
				(min <= other.min).All() &&
				(other.max <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(intrange2 other)
		{
			return (
				(min <= other.max).All() &&
				(other.min <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public intrange2 Intersection(intrange2 other)
		{
			return new intrange2(
				math.max(min, other.min),
				math.min(max, other.max)
			);
		}

		public bool Equals(intrange2 other)
		{
			return (
				(min == other.min).All() &&
				(max == other.max).All()
			);
		}

		public override bool Equals(object obj)
		{
			return obj is intrange2 && Equals((intrange2)obj);
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ (max.GetHashCode() << 2);
		}

		public override string ToString()
		{
			return string.Format("intrange2({0}, {1})", min, max);
		}
	}
}