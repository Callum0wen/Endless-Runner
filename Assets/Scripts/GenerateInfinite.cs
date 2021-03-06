﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class Tile
{
	public GameObject theTile;
	public float creationTime;

	public Tile(GameObject t, float ct)
	{
		theTile = t;	//plane with perlin noise
		creationTime = ct;      //Needed to determine when a tile should be removed
	}
}

public class GenerateInfinite : MonoBehaviour
{
	public GameObject plane;
	public GameObject player;

	//public Text seedText;
	private int seed;

	int planeSize = 10;
	int halfTilesX = 5;	//amount of tiles to render in the x axis away from the player, 10 - player - 10
	int halfTilesZ = 10;	//"" in z

	Vector3 startPos;

	Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
		seed = Random.Range(0, 10000);
		//seedText.text = seed.ToString();

		this.gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		float updateTime = Time.realtimeSinceStartup;

		//Creates 10 tiles in each direction and names them based on coordinates
		for(int x = -halfTilesX; x < halfTilesX; x++)
		{
			for(int z = -halfTilesZ; z < halfTilesZ; z++)
			{
				Vector3 pos = new Vector3((x * planeSize + startPos.x),
											0,
											(z * planeSize + startPos.z));
				GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
				t.GetComponent<GenerateTerrain>().seed = seed;

				string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
				t.name = tilename;
				Tile tile = new Tile(t, updateTime);
				tiles.Add(tilename, tile);
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		//determine how far the player have moved since last terrain update
		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);

		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
		{
			float updateTime = Time.realtimeSinceStartup;

			//force integer position and round the nearest tilesize
			int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
			int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

			for(int x = -halfTilesX; x < halfTilesX; x++)
			{
				for (int z = -halfTilesZ; z < halfTilesZ; z++)
				{
					Vector3 pos = new Vector3((x * planeSize + playerX),
												0,
												(z * planeSize + playerZ));
					string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

					if (!tiles.ContainsKey(tilename))
					{
						GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
						t.GetComponent<GenerateTerrain>().seed = seed;
						t.name = tilename;
						Tile tile = new Tile(t, updateTime);
						tiles.Add(tilename, tile);
					}
					else
					{
						(tiles[tilename] as Tile).creationTime = updateTime;
					}
				}
			}

			//destroy all tiles not just created or with time updates
			//and put new tiles and tiles to be kept in a new hashtable
			Hashtable newTerrain = new Hashtable();
			foreach(Tile tls in tiles.Values)
			{
				if(tls.creationTime != updateTime)
				{
					//delete gameobeject
					Destroy(tls.theTile);
				}
				else
				{
					newTerrain.Add(tls.theTile.name, tls);
				}
			}
			//copy new hashtable contents to the working hashtable
			tiles = newTerrain;

			startPos = player.transform.position;
		}
    }
}
