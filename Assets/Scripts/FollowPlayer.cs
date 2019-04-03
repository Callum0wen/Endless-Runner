using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerPos;
    public Vector3 offset;
	public GameObject bike;
	public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {
		offset.z = -bike.GetComponent<BikeController>().cameraOffset;
		offset.y = 3 + (bike.GetComponent<BikeController>().cameraOffset/4);
		Vector3 desiredPosition = playerPos.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
