using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS
{
    public static class Bool4Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All(this bool4 self)
        {
            return (
                self.x &&
                self.y &&
                self.z &&
                self.w
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any(this bool4 self)
        {
            return (
                self.x ||
                self.y ||
                self.z ||
                self.w
            );
        }
    }
}