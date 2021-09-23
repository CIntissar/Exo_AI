using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TobyManager : AIManager
{
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 6f;
        NextDestination();
    }

    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

}
