using UnityEngine;

public class AccelerateDeccelerate : MonoBehaviour
{

	public HingeJoint hinge;
	public Rigidbody rb;

	void FixedUpdate()
	{
		JointMotor motor = hinge.motor;
		//float acceleration = Input.GetAxis("Vertical");

		if (Input.GetKey("w"))
		{
			motor.force = 5;
		}
		else if (Input.GetKey("s"))
		{
			rb.angularDrag = 200;
		}
		else
		{
			motor.force = 0;
			rb.angularDrag = 0;

		}
		hinge.motor = motor;
		Debug.Log("BackWheel Velocity = " + hinge.velocity);
	}
}
