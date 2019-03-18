using UnityEngine;

public class Jump : MonoBehaviour
{
	public Rigidbody frame;
	public float jumpForce = 1500f;
	public bool onGround = false;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			onGround = true;
			//Debug.Log("Collided with ground");
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetKey("space"))
		{
			if (onGround)
			{
				frame.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}
	}
}
