using UnityEngine;
using Unity.Entities;

public class HelixRotateSystem : ComponentSystem
{
    struct Data
    {
        public Transform transform;
        public HelixRotateComponent helixComponent;
    }

    protected override void OnUpdate()
    {
        var dt = Time.deltaTime;

        foreach(var entity in GetEntities<Data>())
        {
            var rot = entity.transform;

            rot.rotation = rot.rotation * Quaternion.AngleAxis(entity.helixComponent.rotationSpeed * dt, Vector3.up);
        }
    }
}
