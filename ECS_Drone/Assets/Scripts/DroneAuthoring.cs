using Unity.Entities;
using UnityEngine;

public class DroneAuthoring : MonoBehaviour
{
    public float translationSpeed = 2.5f;
    
    class Baker : Baker<DroneAuthoring>
    {
        public override void Bake(DroneAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new DroneMovement
            {
                TranslationSpeed =  authoring.translationSpeed
            });
            
            // AddComponent<Drone>(entity);
        }
    }
}

public struct DroneMovement : IComponentData
{
    public float TranslationSpeed;
}
