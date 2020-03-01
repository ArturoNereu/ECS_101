using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

// Here we work on the system. Note that we are not extending MonoBehaviour, but ComponentSystem so we won't be able to attach this
// script to an object, the System (DroneMoveSystem) will execute over all the objects that meet a criteria (query). That criteria
// is defined as a parameter list on the Foreach method. So, this system will act on all objects that contain a Transform and the DroneMoveComponent components.
public class DroneMoveSystem : ComponentSystem
{   
    // The OnUpdate is similar to our MonoBehaviour Update() however, instead of calling it on a per object basis each frame,
    // we call it once every frame and then iterate over all the entities that match the criteria.
    protected override void OnUpdate()
    {
        float dt = (float)Time.ElapsedTime;

        Entities.ForEach((Entity entity, ref Translation translation, ref DroneMoveComponent droneMoveComponent) =>
        {
            translation.Value = new Vector3(0, math.sin(dt * droneMoveComponent.speed) * 0.5f, 0);
        });
    }
}
