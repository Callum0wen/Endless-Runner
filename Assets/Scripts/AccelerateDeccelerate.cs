using UnityEngine;

public class AccelerateDeccelerate : MonoBehaviour
{

	public HingeJoint hinge;
	public float power = 100f;
	

	void FixedUpdate()
	{
		JointMotor motor = hinge.motor;
		float acceleration = Input.GetAxis("Vertical");

		if (Input.GetKey("w"))
		{
			motor.force = acceleration * power;
			motor.targetVelocity = -200;
			motor.freeSpin = true;
			hinge.motor = motor;
			hinge.useMotor = true;
		}
		if (Input.GetKey("s"))
		{
			motor.force = acceleration * power;
			motor.targetVelocity = 0;
			motor.freeSpin = true;
			hinge.motor = motor;
			hinge.useMotor = true;
		}
	}
}
