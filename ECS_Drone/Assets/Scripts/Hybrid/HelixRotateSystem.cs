using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

// Here we work on the system. Note that we are not extending MonoBehaviour, but ComponentSystem so we won't be able to attach this
// script to an object, the System (HelixRotateSystem) will execute over all the objects that meet a criteria (query). That criteria
// is defined in the Data struct. So, this system will act on all objects that contain a Transform and the HelixRotateComponent.
// But, since we are using the Hybrid approach, we need the entities to also have the GameObjectEntity script attached.
public class HelixRotateSystem : ComponentSystem
{
    // The OnUpdate is similar to our MonoBehaviour Update() however, instead of calling it on a per object basis each frame,
    // we call it once every frame and then iterate over all the entities that match the criteria.
    protected override void OnUpdate()
    {
        float dt = (float)Time.ElapsedTime;

        Entities.ForEach((Entity entity, ref Rotation rotation, ref HelixRotateComponent rotateComponent) =>
        {
            float rotAmount = rotateComponent.speed * dt * Mathf.Deg2Rad;

            quaternion rotQuaternion = quaternion.Euler(0, rotAmount, 0);

            rotation.Value = math.mul(rotation.Value, rotQuaternion);
        });
    }
}
