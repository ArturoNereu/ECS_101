using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed;
    
	void Update ()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
	}
}
