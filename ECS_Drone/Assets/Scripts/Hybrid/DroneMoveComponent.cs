using UnityEngine;

// Here we have the Component part of our drone. Just holding the data (the Transform included).
// We are using the MonoBehaviour to be able to assign the script to the helix. Hence the hybrid approach.
namespace Drone.Hybrid
{
    public class DroneMoveComponent : MonoBehaviour
    {
        public float movementSpeed;
    }
}
