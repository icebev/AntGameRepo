using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{

    private Tilemap destructibleTilemap;
    public float digRadius;
    public Transform diggingObject;

    private Vector3 digLocation;

    // Start is called before the first frame update
    void Start()
    {
        this.destructibleTilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            DestroySurroundingTiles();
        }

        this.digLocation = diggingObject.transform.position;
    }


    private void DestroySurroundingTiles()
    {
        for (int x = -(int)digRadius; x < digRadius; x++)
        {
            for (int y = -(int)digRadius; y < digRadius; y++)
            {
                if (Mathf.Pow(x, 2) + Mathf.Pow(y, 2) < Mathf.Pow(digRadius, 2))
                {
                    Vector3Int tilePos = destructibleTilemap.WorldToCell(this.digLocation + new Vector3(x, y, 0));
                    if (destructibleTilemap.GetTile(tilePos) != null)
                    {
                        DestroyTile(tilePos);
                    }
                }
            }
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.001f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.001f * hit.normal.y;

                Vector3Int tilePos = this.destructibleTilemap.WorldToCell(hitPosition);
            }
        }
    }
    */

    private void DestroyTile(Vector3Int tilePos)
    {
        this.destructibleTilemap.SetTile(tilePos, null);

    }

}
