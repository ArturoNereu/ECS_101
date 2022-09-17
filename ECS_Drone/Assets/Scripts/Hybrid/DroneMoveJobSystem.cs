using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

// public class DroneMoveJobSystem : JobComponentSystem
// {
//     protected override JobHandle OnUpdate(JobHandle inputDeps)
//     {
//         var dt = (float)Time.ElapsedTime;
//
//         Entities.ForEach((ref Translation translation, ref DroneMoveJobComponent droneMoveComponent) =>
//         {
//             translation.Value = new float3(0, math.sin(dt * droneMoveComponent.speed) * 0.5f, 0);
//         }).Run();
//
//         return default;
//     }
// }