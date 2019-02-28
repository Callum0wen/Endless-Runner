using System.Collections;
using UnityEngine;

/**
 * Code from https://www.youtube.com/watch?v=dycHQFEz8VI
**/
public class GenerateTerrain : MonoBehaviour
{
	int heightScale = 4;
	float detailScale = 10f;
	int slope = 3;

	// Start is called before the first frame update
	void Start()
	{
		//Gets the plane and goes through all the vertices, assigning the y value to be equal to the perlin
		//noise value, relative to the detail (i.e. the smoothness), and the height (actual height of the noise).
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		this.transform.Translate(0, -this.transform.position.z / slope, 0);
		for(int v = 0; v < vertices.Length; v++)
		{
			vertices[v].y = (Mathf.PerlinNoise((vertices[v].z + this.transform.position.z) / detailScale,
												(vertices[v].z + this.transform.position.z) / detailScale) * heightScale)
												- (vertices[v].z / slope);
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
