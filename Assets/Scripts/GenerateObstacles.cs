﻿using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
	public Vector3 lastObstacle
	{
		get;
		set;
	}

	private void Start()
	{
		lastObstacle = Vector3.zero;
	}

	public void spawnObstacle (float perlin, Vector3 coordinate, GenerateTerrain plane)
	{
		if((coordinate.z) - (lastObstacle.z + 50) > 0)
		{
			//Spawns logs
			if (perlin > 0.7)
			{
				//Debug.Log("Tree spawned");
				GameObject newLog = LogPool.getLog();
				if (newLog != null)
				{
					Vector3 logPos = new Vector3(coordinate.x,
												coordinate.y,
												coordinate.z);
					lastObstacle = logPos;
					newLog.transform.position = logPos;
					newLog.SetActive(true);
					plane.myObstacles.Add(newLog);
				}
			}

			//Spawns rocks
			if (perlin > 0.5 && perlin < 0.6)
			{
				//Debug.Log("Rock spawned");
				GameObject newRock = RockPool.getRock();
				if (newRock != null)
				{
					Vector3 rockPos = new Vector3(coordinate.x,
												coordinate.y,
												coordinate.z);
					lastObstacle = rockPos;
					newRock.transform.position = rockPos;
					newRock.SetActive(true);
					plane.myObstacles.Add(newRock);
				}
			}
		}
	}
}
