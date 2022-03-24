using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TunnelToLocation : MonoBehaviour
{

    public Tilemap destructibleTileMap;
    public Vector3 targetLocation;
    private Vector3 targetLocationRandomized;
    private float randomizeDelay = 0.2f;
    private float timeCounter = 0;
    public bool isSelected;


    // Start is called before the first frame update
    void Start()
    {
        this.targetLocation = this.gameObject.transform.position;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over the ant.");
        if (!this.isSelected)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = MaterialBank.Highlighted;

        }
    }
    void OnMouseExit()
    {
        if (!this.isSelected)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = MaterialBank.Neutral;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (this.targetLocation.x > this.gameObject.transform.position.x + 3)
        {
            this.gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);

        }
        switch (GlobalVars.b_gamePaused)
        {
            case false:
                TerrainDestroyer.DestroySurroundingTiles(this.destructibleTileMap, this.gameObject.transform.position, 3);
                if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
                {
                    //this.targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //this.targetLocation.z = 0;

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
                break;
        }
    }
}

