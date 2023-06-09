using UnityEngine;

// This component will be assigned to the Drone's propellers. We see that we have the data and the code that transforms it in the same place.
// We have a rotation speed reference as well as one to the object's Transform
namespace Classic
{
    public class HelixRotator : MonoBehaviour
    {
        public float rotationSpeed;

        void Update()
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }
    }
}
