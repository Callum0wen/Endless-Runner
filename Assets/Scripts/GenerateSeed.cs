using UnityEngine;
using UnityEngine.UI;

public class GenerateSeed : MonoBehaviour
{
	public int seed;
	public Text seedText;

    // Start is called before the first frame update
    void Start()
    {
		seed = Random.Range(0, 255);
		seedText.text = seed.ToString();
    }
}
