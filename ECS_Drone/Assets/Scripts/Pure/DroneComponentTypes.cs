using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Drone.Pure
{
    public struct MoveSpeed : IComponentData
    {
        public float speed;
    }

    public struct RotationSpeed : IComponentData
    {
        public float Value;
    }
}