using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public Rigidbody bike;
	public FixedJoint man;
	private bool fallen = false;
	public GameManager gameManager;

	private void OnCollisionEnter(Collision collision)
	{
		if (!fallen && man != null)
		{
			if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Ground")
			{
				bike.constraints = RigidbodyConstraints.None;
				man.breakForce = 1;
				gameManager.EndGame();
				fallen = true;
			}
		}
	}
}
