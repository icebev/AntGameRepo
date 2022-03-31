using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnt : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;

    private bool inPlayerRadius;

    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.updateRotation = false;
        this.agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GlobalVars.b_gamePaused)
        {
            case false:

                if (inPlayerRadius)
                {
                    this.agent.SetDestination(this.target.position);
                }



                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "WorkerAnt")
        {
            
            inPlayerRadius = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WorkerAnt")
        {
            inPlayerRadius = false;
        }
    }
}