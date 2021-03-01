using System;
using Unity.Collections;

namespace CommonECS
{
	public static class NativeArrayExtensions
	{
		public static NativeArray<T> Populate<T>(this NativeArray<T> self, T value)
			where T : struct
		{
			for (int i = 0; i < self.Length; ++i)
				self[i] = value;
			return self;
		}

		public static bool TryIndexOf<T, U>(this NativeArray<T> self, U value, out int index)
			where T : struct, IEquatable<U>
		{
			index = self.IndexOf(value);
			return index != -1;
		}
	}
}