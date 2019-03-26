using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{

		if (collision.collider.name == "Obstacle" || collision.collider.name == "Ground")
		{
			Debug.Log("player was hit");
		}
	}
}
