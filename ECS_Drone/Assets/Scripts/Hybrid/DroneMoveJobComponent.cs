using UnityEngine;
using Unity.Entities;

[SerializeField]
[GenerateAuthoringComponent]
public struct DroneMoveJobComponent : IComponentData
{
    public float speed;
}
