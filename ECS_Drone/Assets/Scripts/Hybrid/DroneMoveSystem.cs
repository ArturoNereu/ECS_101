using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DroneMoveSystem : ComponentSystem
{
    struct Data
    {
        public Transform transform;
        public DroneMoveComponent movementSpeed;
    }

    protected override void OnUpdate()
    {
        var dt = Time.deltaTime;

        foreach(var entity in GetEntities<Data>())
        {
            var pos = entity.transform;

            pos.position += new Vector3(0, entity.movementSpeed.movementSpeed * dt, 0);
        }
    }
}
