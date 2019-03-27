using UnityEngine;

public class BikeCollision : MonoBehaviour
{
	public GameObject pedalFootLeft;
	public GameObject pedalFootRight;
	public GameObject wheelBack;

    // Start is called before the first frame update
    void Start()
    {
		Physics.IgnoreCollision(pedalFootLeft.GetComponent<Collider>(), wheelBack.GetComponent<Collider>());
		Physics.IgnoreCollision(pedalFootRight.GetComponent<Collider>(), wheelBack.GetComponent<Collider>());

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
