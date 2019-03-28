using UnityEngine;

public class WheelCollisionCheck : MonoBehaviour
{
	public bool onGround = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle")
		{
			onGround = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle")
		{
			onGround = false;
		}
	}
}
