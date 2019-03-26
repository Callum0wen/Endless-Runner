using UnityEngine;

public class RockPool : MonoBehaviour
{
	static int numRock = 12;
	public GameObject rock;
	static GameObject[] rocks;

	// Start is called before the first frame update
	void Start()
	{
		rocks = new GameObject[numRock];
		for (int i = 0; i < numRock; i++)
		{
			rocks[i] = (GameObject)Instantiate(rock, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0)));
			rocks[i].tag = "Obstacle";
			rocks[i].SetActive(false);
		}
	}

	static public GameObject getRock()
	{
		for (int i = 0; i < numRock; i++)
		{
			if (!rocks[i].activeSelf)
			{
				return rocks[i];
			}
		}
		return null;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
