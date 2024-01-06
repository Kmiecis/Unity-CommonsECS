using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace CommonECS
{
    public static class NativeListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NativeList<T> Populate<T>(this NativeList<T> self, T value)
            where T : unmanaged
        {
            for (int i = 0; i < self.Length; ++i)
                self[i] = value;
            return self;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryIndexOf<T, U>(this NativeList<T> self, U value, out int index)
            where T : unmanaged, IEquatable<U>
        {
            index = self.IndexOf(value);
            return index != -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGet<T>(this NativeList<T> self, int index, out T value)
            where T : unmanaged
        {
            if (0 > index || index > self.Length - 1)
            {
                value = default;
                return false;
            }
            value = self[index];
            return true;
        }
    }
}