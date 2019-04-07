using UnityEngine;

public class BikeController : MonoBehaviour
{
	private float horizontalInput;
	private float verticalInput;
	private float jump;

	public Rigidbody bike;

	public GameObject wheelBack, wheelFront;

	public Transform pedalShaft, pedalLeft, pedalRight;

	public GameManager gameManager;

	private float maxVelocity = 30f;
	private float bikeForce = 10f;
	private float pedalRotation = 3;
	private float leanForce = 2000f;
	private float jumpForce = 1500f;

	private bool canFall
	{
		get;
		set;
	}
	private float canFallDelay = 2.5f;

	public float cameraOffset = 0f;
	private float minCameraDistance = -5f;
	private float maxCameraDistance = 20f;

	void ResetTensor()
	{
		GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
	}

	private void Start()
	{
		bike.AddForce(0, 0, bikeForce);
		canFall = false;
		Invoke("CanFallTrue", canFallDelay);
	}

	public void GetInput()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		jump = Input.GetAxis("Jump");
	}

	private void Accelerate()
	{
		if (wheelBack.GetComponent<WheelCollisionCheck>().onGround)
		{
			if (verticalInput > 0 && bike.velocity.z < maxVelocity)
			{
				bike.AddForce(0, 0, bikeForce, ForceMode.Acceleration);
				UpdatePedalPose();
			}
			if (verticalInput < 0 && bike.velocity.z > 0)
			{
				wheelBack.GetComponent<Rigidbody>().angularDrag = 200;
			}
			if (verticalInput == 0)
			{
				wheelBack.GetComponent<Rigidbody>().angularDrag = 0;
			}
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
			if (wheelBack.GetComponent<WheelCollisionCheck>().onGround)
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

	private void StopCheck()
	{
		if (canFall && !gameManager.gameOver && bike.velocity.z < 0.1)
		{
			gameManager.EndGame();
		}
	}

	private void CanFallTrue()
	{
		canFall = true;
	}

	private void CameraUpdate()
	{
		if (verticalInput > 0 && cameraOffset < maxCameraDistance)
		{
			cameraOffset += 0.02f;
		}
		if (verticalInput < 0 && cameraOffset > minCameraDistance)
		{
			cameraOffset -= 0.02f;
		}
		if (cameraOffset > minCameraDistance)
		{
			cameraOffset -= 0.01f;
		}
	}


	private void FixedUpdate()
    {
		GetInput();
		Accelerate();
		CameraUpdate();
		StopCheck();
		Jump();
		Lean();
    }
}
