using UnityEngine;

public class BikeController : MonoBehaviour
{
	private float horizontalInput;
	private float verticalInput;
	private float jump;

	public Rigidbody bike;

	public WheelCollider wheelBackC, wheelFrontC;

	public Transform pedalShaft, pedalLeft, pedalRight;

	public float maxVelocity = 30f;

	public float pedalRotation = 3;

	public float motorForce = 5000f;
	public float leanForce = 2000f;
	public float jumpForce = 1500f;
	private WheelHit hit;

	void ResetTensor()
	{
		GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
	}

	public void GetInput()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		jump = Input.GetAxis("Jump");
	}

	private void Accelerate()
	{
		if (verticalInput > 0)
		{
			if (bike.velocity.z < maxVelocity)
			{
				wheelBackC.motorTorque = motorForce;
			}
			UpdatePedalPose();
		}
		if (verticalInput < 0)
		{
			wheelBackC.brakeTorque = motorForce;
		}
		if(verticalInput == 0)
		{
			wheelBackC.motorTorque = 0;
		}
	}

	private void Lean()
	{
		bike.AddTorque(horizontalInput * leanForce, 0, 0);
	}

	private void Jump()
	{
		if (jump > 0)
		{
			if (wheelBackC.GetGroundHit(out hit))
			{
				bike.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}
	}

	private void UpdatePedalPose()
	{
		pedalShaft.transform.Rotate(pedalRotation, 0, 0, Space.Self);
		pedalLeft.transform.Rotate(-pedalRotation, 0, 0, Space.Self);
		pedalRight.transform.Rotate(-pedalRotation, 0, 0, Space.Self);

	}


	private void FixedUpdate()
    {
		GetInput();
		Accelerate();
		Jump();
		Lean();
    }
}
