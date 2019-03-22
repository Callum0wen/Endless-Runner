using System.Collections.Generic;
using UnityEngine;

/**
 * Code from https://www.youtube.com/watch?v=dycHQFEz8VI
**/
public class GenerateTerrain : MonoBehaviour
{
	int heightScale = 8;
	float detailScale = 30f;
	int slope = 3;
	List<GameObject> myLogs = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
	{
		//Gets the plane and goes through all the vertices, assigning the y value to be equal to the perlin
		//noise value, relative to the detail (i.e. the smoothness), and the height (actual height of the noise).
		gameObject.tag = "Ground";
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		this.transform.Translate(0, -this.transform.position.z / slope, 0);
		for(int v = 0; v < vertices.Length; v++)
		{
			float perlin = Mathf.PerlinNoise((vertices[v].z + this.transform.position.z) / detailScale,
												(vertices[v].z + this.transform.position.z) / detailScale);

			vertices[v].y = (perlin * heightScale) - (vertices[v].z / slope);

			if (perlin > 0.9)
			{
				GameObject newLog = LogPool.getLog();
				if(newLog != null)
				{
					Vector3 logPos = new Vector3(this.transform.position.x,
												vertices[v].y,
												vertices[v].z + this.transform.position.z);
					newLog.transform.position = logPos;
					newLog.SetActive(true);
					myLogs.Add(newLog);
				}
			}
		}

		//Reasigns the vertices back to the plane and recalulates so that it renders correctly.
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
