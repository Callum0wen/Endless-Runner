using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
	private Vector3 lastObstacle = new Vector3(0,0,0);

	public void spawnObstacle (float perlin, Vector3 coordinate, GenerateTerrain plane)
	{
		if((plane.transform.position.z + coordinate.z) - (lastObstacle.z + 10) > 0)
		{
			//Spawns logs
			if (perlin > 0.7)
			{
				GameObject newLog = LogPool.getLog();
				if (newLog != null)
				{
					Vector3 logPos = new Vector3(coordinate.x,
												coordinate.y + plane.transform.position.y,
												coordinate.z + plane.transform.position.z);
					lastObstacle = logPos;
					newLog.transform.position = logPos;
					newLog.SetActive(true);
					plane.myObstacles.Add(newLog);
				}
			}

			//Spawns rocks
			if (perlin > 0.5 && perlin < 0.6)
			{
				GameObject newRock = RockPool.getRock();
				if (newRock != null)
				{
					Vector3 rockPos = new Vector3(coordinate.x,
												coordinate.y + plane.transform.position.y,
												coordinate.z + plane.transform.position.z);
					lastObstacle = rockPos;
					newRock.transform.position = rockPos;
					newRock.SetActive(true);
					plane.myObstacles.Add(newRock);
				}
			}
		}
	}
}
