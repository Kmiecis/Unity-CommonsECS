using CommonECS.Extensions;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Mathematics
{
    public static class graphx
    {
        /// <summary>Converts a byte value of range [0..255] to a float value of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float b2f(byte b)
        {
            return b * 1.0f / byte.MaxValue;
        }

        /// <summary>Converts a byte2 values of range [0..255] to a float2 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 b2f(byte2 b)
        {
            return mathx.mul(b, 1.0f) / byte.MaxValue;
        }

        /// <summary>Converts a byte3 values of range [0..255] to a float3 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 b2f(byte3 b)
        {
            return mathx.mul(b, 1.0f) / byte.MaxValue;
        }

        /// <summary>Converts a byte4 values of range [0..255] to a float4 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 b2f(byte4 b)
        {
            return mathx.mul(b, 1.0f) / byte.MaxValue;
        }

        /// <summary>Converts a float value of range [0..1] to a byte value of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte f2b(float f)
        {
            unchecked { return (byte)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float2 values of range [0..1] to a byte2 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 f2b(float2 f)
        {
            unchecked { return (byte2)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float3 values of range [0..1] to a byte3 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 f2b(float3 f)
        {
            unchecked { return (byte3)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float4 values of range [0..1] to a byte4 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 f2b(float4 f)
        {
            unchecked { return (byte4)(f * byte.MaxValue); }
        }

        /// <summary>Converts texture normal vector to unity normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normal(Color c)
        {
            return (c.rgb() * 2.0f - 1.0f).xzy;
        }

        /// <summary>Converts texture normal vector to unity normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normal(Color32 c)
        {
            return (b2f(c.rgb()) * 2.0f - 1.0f).xzy;
        }

        /// <summary>Converts unity normal vector to texture normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color normal(float3 v)
        {
            return ((v.xzy + 1.0f) * 0.5f).color();
        }

        /// <summary>Converts unity normal vector to texture normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 normal32(float3 v)
        {
            return (f2b((v.xzy + 1.0f) * 0.5f)).color();
        }
    }
}
