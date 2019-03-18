using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerPos;
	public Rigidbody player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + offset;
		//offset.z = -player.velocity.z / 3;
		//offset.y = 20 + (player.velocity.z / 30);
	}
}
