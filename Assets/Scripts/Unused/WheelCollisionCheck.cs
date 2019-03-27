using UnityEngine;

public class WheelCollisionCheck : MonoBehaviour
{
	public bool onGround;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("on ground");
			onGround = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("off ground");
			onGround = false;
		}
	}
}
