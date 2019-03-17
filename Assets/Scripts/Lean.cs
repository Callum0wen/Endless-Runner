using UnityEngine;

public class Lean : MonoBehaviour
{
	public Rigidbody rb;
	public float torque = 1500f;

	void ResetTensor()
	{
		GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
	}

	void FixedUpdate()
    {
		if (Input.GetKey("a"))
		{
			//float turn = Input.GetAxis("Vertical");
			rb.AddTorque(-torque, 0, 0);
		}
		if (Input.GetKey("d"))
		{
			
			rb.AddTorque(torque, 0, 0);
		}
	}
}
