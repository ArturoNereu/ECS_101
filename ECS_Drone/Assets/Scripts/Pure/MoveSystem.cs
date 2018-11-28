using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace Drone.Pure
{
    public class MoveSystem : ComponentSystem
    {
        struct Data
        {
            public readonly int Length;
            public ComponentDataArray<Position> Position;
            public ComponentDataArray<MoveSpeed> MoveSpeed;
        }

        [Inject] private Data m_Data;
        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;
            for (int index = 0; index < m_Data.Length; ++index)
            {
                var position = m_Data.Position[index].Value;
                position.y = position.y + (m_Data.MoveSpeed[index].speed * dt);

                m_Data.Position[index] = new Position { Value = position };
            }
        }
    }
}
