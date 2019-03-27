using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 40;
    public int zSize = 20;
	public float detailScale = .1f;
	public float heightScale = 6f;
	public float slope = .2f;
	public Vector2 startOffset;

    // Start is called before the first frame update
    void Start()
    {
		startOffset = new Vector2(Random.Range(0f, 256f), Random.Range(0f, 256f));

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape ()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
				float y = Mathf.PerlinNoise((x + startOffset.x) * detailScale, (x + startOffset.x) * detailScale) * heightScale;
				y = y - (x * slope);
				vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

		triangles = new int[xSize * zSize * 6];
		int vert = 0;
		int tris = 0;
		//Loop assigns the points of two triangles to make a square and loops through all the squares.
		//i.e. 1 square made of 2 triangles, each triangle needs 3 points.
		for (int z = 0; z < zSize; z++)
		{
			for (int x = 0; x < xSize; x++)
			{
				triangles[tris + 0] = vert + 0;
				triangles[tris + 1] = vert + xSize + 1;
				triangles[tris + 2] = vert + 1;
				triangles[tris + 3] = vert + 1;
				triangles[tris + 4] = vert + xSize + 1;
				triangles[tris + 5] = vert + xSize + 2;

				vert++;
				tris += 6;
			}
			vert++;
		}
		
		
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
