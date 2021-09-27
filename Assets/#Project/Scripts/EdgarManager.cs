using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EdgarManager : AIManager
{
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NextDestination();
        agent.speed = 5f;
    }

    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    protected override void NextDestination()
    {
        
        int oldIndexDestination = indexNextDestination;

        while(oldIndexDestination == indexNextDestination && targetPoints.Count >1)
        {
            indexNextDestination = Random.Range(0,targetPoints.Count);
        }
        
        actualDestination = targetPoints[indexNextDestination].GivePoint();  // on peut obtenir un point en Vector3 qui sera sa destination actuelle
        agent.SetDestination(actualDestination); // il va dire à l'agent, sa destination à chaque frame.
        
        if(indexNextDestination >= targetPoints.Count )
        {
            indexNextDestination = 0;
        }

    }
}
