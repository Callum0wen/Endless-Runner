using UnityEngine;

public class BikeWheelPosition : MonoBehaviour
{
	public WheelCollider wheelBackC, wheelFrontC;
	public Transform wheelBackT, wheelFrontT;

	private void UpdateWheelPose(WheelCollider collider, Transform transform)
	{
		Vector3 pos = transform.position;
		Quaternion quat = transform.rotation;

		collider.GetWorldPose(out pos, out quat);

		transform.position = pos;
		transform.rotation = quat;

	}

	private void FixedUpdate()
	{
		UpdateWheelPose(wheelFrontC, wheelFrontT);
		UpdateWheelPose(wheelBackC, wheelBackT);
	}
}
