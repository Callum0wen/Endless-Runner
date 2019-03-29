using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public GameManager gameManager;

	private void OnCollisionEnter(Collision collision)
	{
		if (!gameManager.gameOver)
		{
			if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Ground")
			{
				gameManager.EndGame();
			}
		}
	}
}
