using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    Vector3 spawnPos;
    public Tilemap destructibleTileMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.spawnPos.z = 0;
            TerrainDestroyer.DestroySurroundingTiles(this.destructibleTileMap, this.spawnPos, 5);
            Instantiate(this.antPrefab, this.spawnPos, Quaternion.identity);

        }
    }
}
