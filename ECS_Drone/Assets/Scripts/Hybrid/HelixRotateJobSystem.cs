using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class HelixRotateJobSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dt = (float)Time.ElapsedTime;

        Entities.ForEach((ref Rotation rotation, ref HelixRotateJobComponent rotateComponent) =>
        {
            quaternion rotationQuaternion = float4(0, 1, 0, (rotateComponent.speed * (math.PI/180f))* dt);

            rotation.Value = math.mul(math.normalize(rotation.Value), rotationQuaternion);
        }).Run();

        return default;
    }
}