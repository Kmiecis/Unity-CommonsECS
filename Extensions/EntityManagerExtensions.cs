using Unity.Entities;

namespace CommonECS
{
    public static class EntityManagerExtensions
    {
        public static void EnsureComponentData<T>(this EntityManager self, Entity entity, T data)
            where T : unmanaged, IComponentData
        {
            if (self.HasComponent<T>(entity))
            {
                self.SetComponentData(entity, data);
            }
            else
            {
                self.AddComponentData(entity, data);
            }
        }

        public static bool TryGetComponentData<T>(this EntityManager self, Entity entity, out T data)
            where T : unmanaged, IComponentData
        {
            if (self.HasComponent<T>(entity))
            {
                data = self.GetComponentData<T>(entity);
                return true;
            }
            data = default;
            return false;
        }
    }
}