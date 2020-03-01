using UnityEngine;
using Unity.Entities;

// Here we have the Component part of our Helix. Just holding the data (the Transform included).
// We are using the MonoBehaviour to be able to assign the script to the drone. Hence the hybrid approach.

[GenerateAuthoringComponent]
public struct HelixRotateComponent : IComponentData
{
    public float speed;
}
