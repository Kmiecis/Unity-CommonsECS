using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS
{
	public static class Bool3Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool All(this bool3 self)
		{
			return (
				self.x &&
				self.y &&
				self.z
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Any(this bool3 self)
		{
			return (
				self.x ||
				self.y ||
				self.z
			);
		}
	}
}