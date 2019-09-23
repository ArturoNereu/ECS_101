using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class HelixRotateAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    float rotationSpeed = 0;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new HelixRotateComponent { speed = rotationSpeed });
    }
}
