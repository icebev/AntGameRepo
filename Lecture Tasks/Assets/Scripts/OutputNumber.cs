using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputNumber : MonoBehaviour
{

    [SerializeField] int number;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
