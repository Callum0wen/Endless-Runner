using UnityEngine;

public class LeanAndJump : MonoBehaviour
{
	public Rigidbody rb;
	public float jumpForce = 200f;

	void ResetTensor()
	{
		GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
	}

	void FixedUpdate()
    {
		if (Input.GetKey("space"))
		{
			rb.AddForce(0, jumpForce, 0);
		}
	}
}
