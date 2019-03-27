using UnityEngine;

public class ManNoCollide : MonoBehaviour
{
	public GameObject bike;

    // Start is called before the first frame update
    void Start()
    {
		Physics.IgnoreCollision(this.GetComponent<Collider>(), bike.GetComponent<Collider>());
    }

}
