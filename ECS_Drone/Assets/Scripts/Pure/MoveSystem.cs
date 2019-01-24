using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Drone.Pure
{
    public class MoveSystem : ComponentSystem
    {
        // This version is different from the Hybrid approach just so we can show the lists
        // of contiguous elements Position and MoveSpeed ComponentDataArrays<>
        struct Data
        {
            public readonly int Length;
            public ComponentDataArray<Position> Position;
            public ComponentDataArray<MoveSpeed> MoveSpeed;
        }

        // This inject acts similar to the GetEntities version in our Hybrid approach
        // You can see that the m_Data. is already populated with the objects containing
        // a Position, MoveSpeed in the world
        [Inject] private Data m_Data;
        protected override void OnUpdate()
        {
            float t = Time.time;

            for (int index = 0; index < m_Data.Length; ++index)
            {
                var position = m_Data.Position[index].Value;

                position.y = math.sin(t * m_Data.MoveSpeed[index].speed) * 0.5f ; // note that we are using the sin from the Unity.Mathematics namespace

                m_Data.Position[index] = new Position { Value = position };
            }
        }
    }
}
