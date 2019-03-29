using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerPos;
    public Vector3 offset;
	public GameObject bike;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + offset;
		offset.z = 20 - bike.GetComponent<BikeController>().cameraOffset;
		offset.y = 3 + (bike.GetComponent<BikeController>().cameraOffset/4);
	}
}
