using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	public struct intrange
	{
		public int min;
		public int max;

		public static readonly range zero;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public intrange(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		public float Center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return (max + min) * 0.5f; }
		}

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return max - min; }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int i)
		{
			return min <= i && i <= max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(intrange other)
		{
			return min <= other.min && other.max <= max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(intrange other)
		{
			return min <= other.max && other.min <= max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public intrange Intersection(intrange other)
		{
			return new intrange(
				math.max(min, other.min),
				math.min(max, other.max)
			);
		}

		public bool Equals(intrange other)
		{
			return (
				min == other.min &&
				max == other.max
			);
		}

		public override bool Equals(object obj)
		{
			return obj is intrange && Equals((intrange)obj);
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ (max.GetHashCode() << 2);
		}

		public override string ToString()
		{
			return string.Format("intrange({0}, {1})", min, max);
		}
	}
}