using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	[Serializable]
	public struct range3 : IEquatable<range3>
	{
		public float3 min;
		public float3 max;

		public static readonly range3 Zero;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range3(float3 min, float3 max)
		{
			this.min = min;
			this.max = max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range3(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
		{
			this.min = new float3(minX, minY, minZ);
			this.max = new float3(maxX, maxY, maxZ);
		}

		public float3 Center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return (max + min) * 0.5f; }
		}

		public float3 Extents
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get { return max - min; }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(float x, float y, float z)
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
		public bool Contains(float3 v)
		{
			return Contains(v.x, v.y, v.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(range3 other)
		{
			return (
				(min <= other.min).All() &&
				(other.max <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(range3 other)
		{
			return (
				(min <= other.max).All() &&
				(other.min <= max).All()
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public range3 Intersection(range3 other)
		{
			return new range3(
				math.max(min, other.min),
				math.min(max, other.max)
			);
		}

		public bool Equals(range3 other)
		{
			return (
				mathx.isequal(min, other.min) &&
				mathx.isequal(max, other.max)
			);
		}

		public override bool Equals(object obj)
		{
			return obj is range3 && Equals((range3)obj);
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ (max.GetHashCode() << 2);
		}

		public override string ToString()
		{
			return string.Format("range3({0}, {1})", min, max);
		}
	}
}