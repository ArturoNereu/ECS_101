using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float translationSpeed;
	
	void Update ()
    {
        transform.position += new Vector3(0, translationSpeed, 0) * Time.deltaTime;	
	}
}
