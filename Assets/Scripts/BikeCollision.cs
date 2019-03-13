using UnityEngine;

public class BikeCollision : MonoBehaviour
{
	public GameObject frame;
	public GameObject pedalShaft;
	public GameObject pedalFoot;
	public GameObject wheelBack;
	public GameObject wheelFront;

    // Start is called before the first frame update
    void Start()
    {
		Physics.IgnoreCollision(pedalFoot.GetComponent<Collider>(), frame.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), pedalShaft.GetComponent<Collider>());
		Physics.IgnoreCollision(pedalFoot.GetComponent<Collider>(), pedalShaft.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), pedalFoot.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), wheelBack.GetComponent<Collider>());
		Physics.IgnoreCollision(this.GetComponent<Collider>(), wheelFront.GetComponent<Collider>());

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
