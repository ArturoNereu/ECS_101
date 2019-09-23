using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class DroneMoveAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    float movementSpeed = 0;    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new DroneMoveComponent{ speed = movementSpeed });
    }
}
