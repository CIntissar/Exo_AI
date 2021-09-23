using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimonManager : AIManager
{

    void Start()
    {
        agent.speed = 4f;
    }

    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    public override void NextDestination()
    {
        indexNextDestination = 0;

        actualDestination = targetPoints[indexNextDestination].GivePoint();  // on peut obtenir un point en Vector3 qui sera sa destination actuelle
        agent.SetDestination(actualDestination); // il va dire à l'agent, sa destination à chaque frame.

    }

}
