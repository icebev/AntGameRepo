using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSpawn : MonoBehaviour
{

    public int buildingRadius;
    public bool randomiseOrientation;
    public Tilemap destructibleTiles;
    private bool hasClearedTiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.hasClearedTiles)
        {
            if (this.randomiseOrientation)
            {
                this.gameObject.transform.Rotate(0, 0, (float)(Random.Range(0, 3) * 90));
            }
            TerrainDestroyer.DestroySurroundingTiles(this.destructibleTiles, this.gameObject.transform.position, this.buildingRadius);

            this.hasClearedTiles = true;
        }
        
    }
}
