﻿using System.Collections.Generic;
using UnityEngine;

/**
 * Code from https://www.youtube.com/watch?v=dycHQFEz8VI
**/
public class GenerateTerrain : MonoBehaviour
{
	public GameObject landscape;

	int heightScale = 8;
	float detailScale = 40f;
	int slope = 3;
	public List<GameObject> myObstacles = new List<GameObject>();
	public int seed;

	// Start is called before the first frame update
	void Start()
	{
		GenerateObstacles genObsScript = landscape.GetComponent<GenerateObstacles>();
		if (this.transform.position == Vector3.zero)
		{
			genObsScript.lastObstacle = Vector3.zero;
		}
		//Gets the plane and goes through all the vertices, assigning the y value to be equal to the perlin
		//noise value, relative to the detail (i.e. the smoothness), and the height (actual height of the noise).
		gameObject.tag = "Ground";
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		this.transform.Translate(0, -this.transform.position.z / slope, 0);
		for(int v = 0; v < vertices.Length; v++)
		{
			float perlin = Mathf.PerlinNoise(((vertices[v].z + this.transform.position.z) / detailScale) + seed,
												((vertices[v].z + this.transform.position.z) / detailScale) + seed);

			vertices[v].y = (perlin * heightScale) - (vertices[v].z / slope);

			if (this.transform.position.x == 0 && Mathf.Round(vertices[v].x) == -3)
			{
				genObsScript.spawnObstacle(perlin, vertices[v] + this.transform.position, this);
			}

			
		}

		//Reasigns the vertices back to the plane and recalulates so that it renders correctly.
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();
	}

	private void OnDestroy()
	{
		for(int i = 0; i< myObstacles.Count; i++)
		{
			if(myObstacles[i] != null)
			{
				myObstacles[i].SetActive(false);
			}
 		}
		myObstacles.Clear();
	}
}
