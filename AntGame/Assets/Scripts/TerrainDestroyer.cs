using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TerrainDestroyer
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //private Tilemap destructibleTilemap;
    //public float digRadius;
    //public Transform diggingObject;

    //private Vector3 digLocation;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    this.destructibleTilemap = GetComponent<Tilemap>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        DestroySurroundingTiles();
    //    }

    //    this.digLocation = diggingObject.transform.position;
    //}


    public static void DestroySurroundingTiles(Tilemap tilemap,  Vector3 digLocation, float digRadius)
    {
        for (int x = -(int)digRadius; x < digRadius; x++)
        {
            for (int y = -(int)digRadius; y < digRadius; y++)
            {
                if (Mathf.Pow(x, 2) + Mathf.Pow(y, 2) < Mathf.Pow(digRadius, 2))
                {
                    Vector3Int tilePos = tilemap.WorldToCell(digLocation + new Vector3(x, y, 0));
                    if (tilemap.GetTile(tilePos) != null)
                    {
                        TerrainDestroyer.DestroyTile(tilemap, tilePos);
                    }
                }
            }
        }
    }

    private static void DestroyTile(Tilemap tilemap, Vector3Int tilePos)
    {
        tilemap.SetTile(tilePos, null);

    }

}
