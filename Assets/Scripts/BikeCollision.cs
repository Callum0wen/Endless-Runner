using UnityEngine;

public class BikeCollision : MonoBehaviour
{
	public GameObject frame;
	public GameObject pedalShaft;
	public GameObject pedalFootLeft;
	public GameObject pedalFootRight;
	public GameObject wheelBack;
	public GameObject wheelFront;

    // Start is called before the first frame update
    void Start()
    {
		Physics.IgnoreCollision(pedalFootLeft.GetComponent<Collider>(), frame.GetComponent<Collider>());
		Physics.IgnoreCollision(pedalFootRight.GetComponent<Collider>(), frame.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), pedalShaft.GetComponent<Collider>());
		Physics.IgnoreCollision(pedalFootLeft.GetComponent<Collider>(), pedalShaft.GetComponent<Collider>());
		Physics.IgnoreCollision(pedalFootRight.GetComponent<Collider>(), pedalShaft.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), wheelBack.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), wheelFront.GetComponent<Collider>());

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
