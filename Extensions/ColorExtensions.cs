using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Extensions
{
    public static class ColorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rgb(this Color self)
            => new float3(self.r, self.g, self.b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rgba(this Color self)
            => new float4(self.r, self.g, self.b, self.a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color color(this float3 self)
            => new Color(self.x, self.y, self.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color color(this float4 self)
            => new Color(self.x, self.y, self.z, self.w);
    }
}