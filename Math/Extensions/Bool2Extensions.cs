using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS
{
	public static class Bool2Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool All(this bool2 self)
		{
			return (
				self.x &&
				self.y
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Any(this bool2 self)
		{
			return (
				self.x ||
				self.y
			);
		}
	}
}