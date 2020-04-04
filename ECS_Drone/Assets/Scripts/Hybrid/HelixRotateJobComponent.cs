using Unity.Entities;
using UnityEngine;

[SerializeField]
[GenerateAuthoringComponent]
public struct HelixRotateJobComponent : IComponentData
{ 
    public float speed;
}
