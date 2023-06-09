using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct HelixRotateSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<HelixRotation>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var dt = SystemAPI.Time.DeltaTime;
        
        foreach (var (helixRotation, transform) in
                 SystemAPI.Query<HelixRotation, RefRW<LocalTransform>>()
                     .WithAll<HelixRotation>())
        {
            var speed = helixRotation.RotationSpeed;

            var spin =  quaternion.RotateY(speed * dt * math.PI);
            
            transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
        }
    }
}