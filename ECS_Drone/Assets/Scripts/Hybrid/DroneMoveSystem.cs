using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class DroneMoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float dt = (float)Time.ElapsedTime;

        Entities.ForEach((Entity entity, ref Translation translation, ref DroneMoveComponent droneMoveComponent) =>
        {
            translation.Value.y = math.sin(dt * droneMoveComponent.speed) * 0.5f;
        });
    }
    
    /*protected override void OnStartRunning()
    {
        Entities.ForEach((Entity entity, ref Translation translation, ref DroneMoveComponent droneMoveComponent) =>
        {
            droneMoveComponent.speed = Random.Range(1.5f, 3.5f);
            translation.Value = new Vector3(Random.Range(-20.0f, 20.0f), 0.308f, Random.Range(-20.0f, 20.0f));
        });
    }*/
}