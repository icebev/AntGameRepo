using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject rogObject;
    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Rotate()

        this.rogObject.transform.Rotate(0, 0, this.spinSpeed * Time.deltaTime);
    }
}
