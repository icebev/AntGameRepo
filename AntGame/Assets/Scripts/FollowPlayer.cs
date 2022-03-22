using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.updateRotation = false;
        this.agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.agent.SetDestination(this.target.position);
    }
}
