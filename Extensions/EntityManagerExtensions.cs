using Unity.Entities;

namespace CommonECS
{
	public static class EntityManagerExtensions
	{
		public static void EnsureComponentData<T>(this EntityManager entityManager, Entity entity, T componentData)
			where T : struct, IComponentData
		{
			if (entityManager.HasComponent<T>(entity))
				entityManager.SetComponentData(entity, componentData);
			else
				entityManager.AddComponentData(entity, componentData);
		}
	}
}