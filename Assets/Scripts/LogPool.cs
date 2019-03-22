using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPool : MonoBehaviour
{
	static int numLog = 2;
	public GameObject log;
	static GameObject[] logs;

    // Start is called before the first frame update
    void Start()
    {
		logs = new GameObject[numLog];
		for (int i = 0; i < numLog; i++)
		{
			logs[i] = (GameObject)Instantiate(log, Vector3.zero, Quaternion.identity);
			logs[i].SetActive(false);
		}
    }

	static public GameObject getLog()
	{
		for(int i = 0; i < numLog; i++)
		{
			if(!logs[i].activeSelf)
			{
				return logs[i];
			}
		}
		return null;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
