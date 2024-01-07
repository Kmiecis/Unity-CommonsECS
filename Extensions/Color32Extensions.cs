using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CommonECS.Extensions
{
    public static class Color32Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rgb(this Color32 self)
            => new byte3(self.r, self.g, self.b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rgba(this Color32 self)
            => new byte4(self.r, self.g, self.b, self.a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 color(this byte3 self)
            => new Color32(self.x, self.y, self.z, byte.MaxValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 color(this byte4 self)
            => new Color32(self.x, self.y, self.z, self.w);
    }
}