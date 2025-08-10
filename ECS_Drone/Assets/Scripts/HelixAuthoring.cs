using Unity.Entities;
using UnityEngine;

public class HelixAuthoring : MonoBehaviour
{
    public float rotationSpeed = 2.5f;

    class Baker : Baker<HelixAuthoring>
    {
        public override void Bake(HelixAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new HelixRotation()
            {
                RotationSpeed = authoring.rotationSpeed
            });
        }
    }
}

public struct HelixRotation : IComponentData
{
    public float RotationSpeed;
}
