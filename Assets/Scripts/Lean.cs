using UnityEngine;

public class Lean : MonoBehaviour
{
	public Rigidbody rb;
	public float torque = 20f;

	void ResetTensor()
	{
		GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
	}

	void FixedUpdate()
    {
		if (Input.GetKey("a"))
		{
			float turn = Input.GetAxis("Vertical");
			rb.AddTorque(transform.right * torque * turn);
		}
		if (Input.GetKey("d"))
		{
			float turn = Input.GetAxis("Vertical");
			rb.AddTorque(transform.right * -torque * turn);
		}
	}
}
