using UnityEngine;

public class Jump : MonoBehaviour
{
	public Rigidbody rb;
	public float jumpForce = 800f;
	private bool onGround = false;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			onGround = true;
			Debug.Log("Collided with ground");
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
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}
	}
}
