using Unity.Entities;
using UnityEngine;

namespace Common.ECS
{
    public abstract class AuthoringBehaviour<TComponent> : MonoBehaviour
        where TComponent : unmanaged, IComponentData
    {
        public virtual bool MarkDependencies(IBaker baker)
            => true;

        public virtual TComponent AsComponent(IBaker baker)
            => new TComponent();

        public virtual void Bake(IBaker baker)
        {
            if (!MarkDependencies(baker))
                return;

            var target = baker.GetEntity(TransformUsageFlags.Dynamic);
            baker.AddComponent(target, AsComponent(baker));
        }
    }
}