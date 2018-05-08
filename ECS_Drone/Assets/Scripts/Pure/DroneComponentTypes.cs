using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct DroneComponent : IComponentData
{
    public float movementSpeed;
}

public struct HelixComponent : IComponentData
{
    public float rotationSpeed;
}

public struct Drone : IComponentData { }
public struct Helix : IComponentData { }