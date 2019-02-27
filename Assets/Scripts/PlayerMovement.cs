using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;

	public float force = 500f;

    // Fixed update tp update the physics
    void FixedUpdate()
    {
        if(Input.GetKey("w"))
		{
			rb.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -force * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}
}
