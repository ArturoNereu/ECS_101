using UnityEngine;

// This component is assigned to the Drone to manage it's movement. Contains both the data and the code that transforms it.
// In this particular case, we just have a reference to the translationSpeed, but we inherently reference the object's Transform (Position, Rotation, Scale)
namespace Classic
{
    public class DroneMovement : MonoBehaviour
    {
        public float translationSpeed;

        void Update()
        {
            transform.position = new Vector3(0, Mathf.Sin(Time.time * translationSpeed) * 0.5f, 0);
        }
    }
}
