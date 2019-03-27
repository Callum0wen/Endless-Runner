using UnityEngine;

public class WheelCollisionCheck : MonoBehaviour
{
	public bool onGround;

	private void OnTriggerEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("on ground");
			onGround = true;
		}
	}

	private void OnTriggerExit(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("off ground");
			onGround = false;
		}
	}
}
