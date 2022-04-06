using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWarClear : MonoBehaviour
{

    Tilemap fogOfWarMap;
    public float lookRadius;

    // Start is called before the first frame update
    void Start()
    {
        this.fogOfWarMap = GameObject.FindWithTag("FogOfWar").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        TerrainDestroyer.DestroySurroundingTiles(this.fogOfWarMap, this.transform.position, this.lookRadius);
    }
}
