using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    Vector3 spawnPos;
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
            Instantiate(this.antPrefab, this.spawnPos, Quaternion.identity);
        }
    }
}
