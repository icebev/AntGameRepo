using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusFarm : MonoBehaviour
{
    public float farmRadius;
    public ResourceManager resourceManager;
    public Transform workerAntTest;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (GlobalVars.b_gamePaused)
        {

            case false:
                this.FarmFungus();
                break;
        }
    }

    public void FarmFungus()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, this.farmRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("WorkerAnt"))
            {
                this.resourceManager.AddFungus(10);

            }
            
        }

        if (Vector3.Distance(this.gameObject.transform.position, this.workerAntTest.position) <= 10)
        {
            this.resourceManager.AddFungus(1);
        }
    }
}
