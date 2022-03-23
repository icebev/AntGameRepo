using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TunnelToLocation : MonoBehaviour
{

    public Tilemap destructibleTileMap;
    private Vector3 targetLocation;
    private Vector3 targetLocationRandomized;
    private float randomizeDelay = 0.2f;
    private float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.targetLocation = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TerrainDestroyer.DestroySurroundingTiles(this.destructibleTileMap, this.gameObject.transform.position, 3);
        if (Input.GetButtonDown("Fire1"))
        {
            this.targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.targetLocation.z = 0;

        }


        timeCounter += Time.deltaTime;
        if (timeCounter > randomizeDelay)
        {
            float currentDelta = Vector3.Distance(this.gameObject.transform.position, this.targetLocation);
            this.targetLocationRandomized.x = this.targetLocation.x + (Random.value - 0.5f) * 1.2f * currentDelta;
            this.targetLocationRandomized.y = this.targetLocation.y + (Random.value - 0.5f) * 1.2f * currentDelta;
            timeCounter = 0;
        }

        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.targetLocationRandomized, 15f * Time.deltaTime);
    }
}

