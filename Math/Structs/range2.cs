using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	[Serializable]
	public struct range2 : IEquatable<range2>
	{
		public float2 min;
		public float2 max;

		public static readonly range2 zero;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range2(float2 min, float2 max)
		{
			this.min = min;
			this.max = max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range2(float minX, float minY, float maxX, float maxY)
		{
			this.min = new float2(minX, minY);
			this.max = new float2(maxX, maxY);
		}

		public float2 Center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return (max + min) * 0.5f; }
		}

		public float2 Size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return max - min; }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(float x, float y)
		{
			return (
				min.x <= x &&
				min.y <= y &&
				x <= max.x &&
				y <= max.y
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(float2 v)
		{
			return Contains(v.x, v.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(range2 other)
		{
			return (
				(min <= other.min).All() &&
				(other.max <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(range2 other)
		{
			return (
				(min <= other.max).All() &&
				(other.min <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range2 Intersection(range2 other)
		{
			return new range2(
				math.max(min, other.min),
				math.min(max, other.max)
			);
		}

		public bool Equals(range2 other)
		{
			return (
				mathx.isequal(min, other.min) &&
				mathx.isequal(max, other.max)
			);
		}

		public override bool Equals(object obj)
		{
			return obj is range2 && Equals((range2)obj);
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ (max.GetHashCode() << 2);
		}

		public override string ToString()
		{
			return string.Format("range2({0}, {1})", min, max);
		}
	}
}