using Unity.Entities;

namespace Drone.Pure
{
    // This struct is a way to wrap our blittable data(https://en.wikipedia.org/wiki/Blittable_types) so in our systems
    // we can set lists of these types. 
    // For simplicity both structs are defined in the same file.

    public struct MoveSpeed : IComponentData
    {
        public float speed;
    }

    public struct RotationSpeed : IComponentData
    {
        public float Value;
    }
}