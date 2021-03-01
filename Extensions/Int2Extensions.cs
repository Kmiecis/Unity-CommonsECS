using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS
{
	public static class Int2Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 xy_(this int2 v)
		{
			return new int3(v.x, v.y, 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 x_y(this int2 v)
		{
			return new int3(v.x, 0, v.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 _xy(this int2 v)
		{
			return new int3(0, v.x, v.y);
		}
	}
}