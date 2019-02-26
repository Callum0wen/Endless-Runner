using System.Collections;
using UnityEngine;

/**
 * Code from https://www.youtube.com/watch?v=dycHQFEz8VI
**/
public class GenerateTerrain : MonoBehaviour
{
	int heightScale = 4;
	float detailScale = 10f;

	// Start is called before the first frame update
	void Start()
	{
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for(int v = 0; v < vertices.Length; v++)
		{
			vertices[v].y = (Mathf.PerlinNoise((vertices[v].z + this.transform.position.z) / detailScale,
												(vertices[v].z + this.transform.position.z) / detailScale) * heightScale)
												- (this.transform.position.z + (v/11));
		}

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
