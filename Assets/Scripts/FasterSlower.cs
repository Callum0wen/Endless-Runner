using UnityEngine;

public class FasterSlower : MonoBehaviour
{
	public Rigidbody frame;
	public GameObject backWheel;
	public float maxVelocity = 30f;
	public float acceleration = 0.1f;
	private float baseVelocity = 0.1f;
	private bool fallen = false;

	private void FixedUpdate()
	{
		frame.velocity = frame.velocity + (transform.up * baseVelocity); 

		if (backWheel.GetComponent<Jump>().onGround)
		{
			acceleration = Mathf.Clamp(frame.velocity.z / 10, 1, 10);

			if (Input.GetKey("w") && frame.velocity.z < maxVelocity)
			{
				backWheel.GetComponent<Rigidbody>().angularDrag = 0;
				frame.velocity = frame.velocity + (transform.up * acceleration);
				//frame.AddForce(accelerate * Time.deltaTime);
			}
			if (Input.GetKey("s") && frame.velocity.z > 0)
			{
				backWheel.GetComponent<Rigidbody>().angularDrag = 100;
				//frame.velocity = -transform.up * acceleration;
				//frame.AddForce(-accelerate * Time.deltaTime);
			} else
			{
				backWheel.GetComponent<Rigidbody>().angularDrag = 0;
			}
			if (frame.velocity.z < 3 && !fallen)
			{
				frame.constraints = RigidbodyConstraints.None;
				fallen = true;
				Debug.Log("fall");
			}
		}
		//Debug.Log(frame.velocity.z);
	}
}
