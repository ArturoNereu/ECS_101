using UnityEngine;
using Unity.Entities;

// Here we work on the system. Note that we are not extending MonoBehaviour, but ComponentSystem so we won't be able to attach this
// script to an object, the System (DroneMoveSystem) will execute over all the objects that meet a criteria (query). That criteria
// is defined in the Data struct. So, this system will act on all objects that contain a Transform and the DroneMoveComponents.
// But, since we are using the Hybrid approach, we need the entities to also have the GameObjectEntity script attached.
namespace Drone.Hybrid
{
    public class DroneMoveSystem : ComponentSystem
    {
        struct Data
        {
            public Transform transform;
            public DroneMoveComponent movementSpeed;
        }

        // The OnUpdate is similar to our MonoBehaviour Update() however, instead of calling it on a per object basis each frame,
        // we call it once every frame and then iterate over all the entities that match the criteria.
        protected override void OnUpdate()
        {
            var dt = Time.time;

            foreach (var entity in GetEntities<Data>())
            {
                var pos = entity.transform;

                pos.position = new Vector3(0, Mathf.Sin(Time.time * entity.movementSpeed.movementSpeed) * 0.5f, 0);
            }
        }
    }
}
