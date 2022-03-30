using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogGenerator : MonoBehaviour
{
    int[,] mapArray;

    Tilemap tilemap;
    public TileBase tile;

    public int startingFogWidth;
    public int startingFogHeight; // Also the maximum ground level
    // Start is called before the first frame update
    void Start()
    {
        this.tilemap = GetComponent<Tilemap>();
        this.mapArray = GenerateArray(this.startingFogWidth, this.startingFogHeight, false);
        RenderMap(this.mapArray, this.tilemap, this.tile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }

    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

}
