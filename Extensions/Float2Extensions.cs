using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS
{
	public static class Float2Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 xy_(this float2 v)
		{
			return new float3(v.x, v.y, 0.0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 x_y(this float2 v)
		{
			return new float3(v.x, 0.0f, v.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 _xy(this float2 v)
		{
			return new float3(0.0f, v.x, v.y);
		}
	}
}