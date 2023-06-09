using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct DroneMoveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<DroneMovement>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var t = (float)SystemAPI.Time.ElapsedTime;
        
        foreach (var (droneMovement, transform) in
                 SystemAPI.Query<DroneMovement, RefRW<LocalTransform>>()
                     .WithAll<DroneMovement>())
        {
            var speed = droneMovement.TranslationSpeed;

            var pos = new float3(0, math.sin(speed * t) + 0.5f, 0);

            transform.ValueRW.Position = pos;
        }
    }
}
