using UnityEngine;
using Unity.Entities;

// Here we work on the system. Note that we are not extending MonoBehaviour, but ComponentSystem so we won't be able to attach this
// script to an object, the System (HelixRotateSystem) will execute over all the objects that meet a criteria (query). That criteria
// is defined in the Data struct. So, this system will act on all objects that contain a Transform and the HelixRotateComponent.
// But, since we are using the Hybrid approach, we need the entities to also have the GameObjectEntity script attached.
namespace Drone.Hybrid
{
    public class HelixRotateSystem : ComponentSystem
    {
        struct Data
        {
            public Transform transform;
            public HelixRotateComponent helixComponent;
        }

        // The OnUpdate is similar to our MonoBehaviour Update() however, instead of calling it on a per object basis each frame,
        // we call it once every frame and then iterate over all the entities that match the criteria.
        protected override void OnUpdate()
        {
            var dt = Time.deltaTime;

            foreach (var entity in GetEntities<Data>())
            {
                var rot = entity.transform;

                rot.rotation = rot.rotation * Quaternion.AngleAxis(entity.helixComponent.rotationSpeed * dt, Vector3.up);
            }
        }
    }
}
