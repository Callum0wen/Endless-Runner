using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public GameObject bike;
	public FixedJoint man;

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Ground")
		{
			bike.GetComponent<BikeController>().enabled = false;
			bike.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			man.breakForce = 1;
		}
	}
}
