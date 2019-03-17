using UnityEngine;

public class FasterSlower : MonoBehaviour
{
	public Rigidbody frame;
	public GameObject backWheel;
	public float maxVelocity = 1600f;
	public Vector3 accelerate = new Vector3 (0,0, 330);

	private void FixedUpdate()
	{
		if (backWheel.GetComponent<Jump>().onGround)
		{
			if (Input.GetKey("w"))
			{
				if (frame.velocity.z < maxVelocity)
				{
					frame.velocity += accelerate;
					Debug.Log(frame.velocity.z);
				}
			}
			if (Input.GetKey("s"))
			{
				if (frame.velocity.z > 0)
				{
					frame.velocity -= accelerate;
					Debug.Log("Slower!");
				}
			}
		}
	}
}
